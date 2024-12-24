using System;
using System.Text;

public class IronChallengeOldPhonePad {
    const char BackspaceKey = '*';
    const char SendKey = '#';
    const char PauseKey = ' ';

    /* array of strings where each entry denotes the arranged characters against the index */
    static string[] arrangements = new[] {" ", "&'(", "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"};

    static char GetResultingCharacter(char key, int numberOfStroke) {
        int keyIndex = key - '0';
        int characterCount = arrangements[keyIndex].Length;

        /* pressing a button multiple times will cycle through the letters*/
        return arrangements[keyIndex][(numberOfStroke - 1) % characterCount]; 
    }

    public static void CheckSanity(string input) {  
        /* Check if last character is send key */
        if(input.Length == 0 || input[input.Length - 1] != SendKey) {
            throw new Exception("Invalid input: Send key not found at the end of input");
        }

        /* Check if all characters till the send key are either digit or backspace key or pause key */
        char[] SpecialKeys = {BackspaceKey, PauseKey};

        for(int i = 0; i < input.Length - 1; i++) {
            char c = input[i];
            if(!char.IsDigit(c) && Array.IndexOf(SpecialKeys, c) == -1) {
                throw new Exception($"Invalid input: {c} is not a valid key at position {i+1}");
            }
        }
        
    }

    public static string OldPhonePad(string input) {
        CheckSanity(input);
        StringBuilder result = new StringBuilder();
        int l = 0; // l is the number of keys processed from front
        int n = input.Length;

        while(l < n) {
            char key = input[l++];

            /* Handle special keys at first*/
            if(key == SendKey) {
                break;
            }
            else if(key == PauseKey) {
                continue;
            }
            else if(key == BackspaceKey) {
                if(result.Length > 0) {
                    result.Length--;  // Keeping it O(1)
                }
                continue;
            }

            /* Count the number of times the key is pressed consecutively*/
            int numberOfStroke = 1;
            while(l < n && input[l] == key) {
                numberOfStroke++;
                l++;
            }
            result.Append(GetResultingCharacter(key, numberOfStroke));
        }

        return result.ToString();
    }

    public static void Main(string[] args) {
        if(args.Length == 0) {
            Console.Error.WriteLine("Please provide input");
            return;
        }
        try {
            Console.WriteLine(OldPhonePad(args[0]));
        } catch(Exception e) {
            Console.Error.WriteLine(e.Message);
        }
    }
}