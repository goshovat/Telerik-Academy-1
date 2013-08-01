using System;

/*
    Declare two string variables and assign them with following value:
    The "use" of quotations causes difficulties.
    Do the above in two different ways: with and without using quoted strings.
*/

class StringVariables
{
    static void Main(string[] args)
    {
        string quotedString = @"The ""use"" of quotations causes difficulties.";
        string unquotedString = "The \"use\" of quotations causes difficulties.";
        Console.WriteLine("Quoted string - {0} \nUnquoted string - {1}", quotedString, unquotedString);
    }
}

