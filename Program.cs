using System;
using System.Text;
using System.Collections.Generic;

public class IronChallengeOldPhonePad {
    const char BackspaceKey = '*';
    const char SendKey = '#';
    const char PauseKey = ' ';

    /* array of strings where each entry denotes the arranged characters against the index */
    static string[] arrangements = new[] {" ", "&'(", "ABC", "DEF", "GHI", "JKL", "MNO", "PQRS", "TUV", "WXYZ"};

    static char GetResultingCharacter(char key, int numberOfStroke) {
        int keyIndex = key - '0';
        if(arrangements[keyIndex].Length < numberOfStroke) {
            throw new Exception($"Invalid input: {key} occurs {numberOfStroke} times consecutively");
        }
        return arrangements[keyIndex][numberOfStroke - 1];
    }

    public static void CheckSanity(string input) {  
        if(input.Length == 0 || input[input.Length - 1] != SendKey) {
            throw new Exception("Invalid input: Send key not found at the end of input");
        }

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
        Queue<char> inputQueue = new Queue<char>(input);

        while(inputQueue.Count > 0) {
            char key = inputQueue.Dequeue();
 
            if(key == SendKey) {
                break;
            }
            else if(key == PauseKey) {
                continue;
            }
            else if(key == BackspaceKey) {
                if(result.Length > 0) {
                    result.Length --;
                }
                continue;
            }

            int numberOfStroke = 1;
            while(inputQueue.Count > 0 && inputQueue.Peek() == key) {
                numberOfStroke++;
                inputQueue.Dequeue();
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