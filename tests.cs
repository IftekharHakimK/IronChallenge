using System;
using Xunit;
public class Tests
{
    [Theory]
    [InlineData("", "Invalid input: Send key not found at the end of input")]
    [InlineData("1234", "Invalid input: Send key not found at the end of input")]
    [InlineData("1234a5~!#", "Invalid input: a is not a valid key at position 5")]
    [InlineData("211111#", "Invalid input: 1 occurs 5 times consecutively")]
    [InlineData("1122##", "Invalid input: # is not a valid key at position 5")]
    public void TestAgainstBadInputs(string input, string expected)
    {
        var exception = Assert.Throws<Exception>(() => IronChallengeOldPhonePad.OldPhonePad(input));
        Assert.Equal(expected, exception.Message);
    }

    [Theory]
    [InlineData("33#", "E")]
    [InlineData("227*#", "B")]
    [InlineData("4433555 555666#", "HELLO")]
    [InlineData("8 88777444666*664#", "TURING")]
    [InlineData("444333833 55  44 333* 2777#", "IFTEKHAR")]
    [InlineData("551  11  111*111 11215313113*67*#", "K&'('A&JD&D'M")]
    public void TestAgainstGoodInputs(string input, string expected)
    {
        Assert.Equal(expected, IronChallengeOldPhonePad.OldPhonePad(input));
    }
}