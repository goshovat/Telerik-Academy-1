using System;

class IntegerVariables
{
    /*
        Declare five variables choosing for each of them the most appropriate of the types byte, 
        sbyte, short, ushort, int, uint, long, ulong to represent the following values: 
        52130, -115, 4825932, 97, -10000.
    */
    static void Main(string[] args)
    {
        sbyte signedByteVariable = -115;
        byte unsignedByteVariable = 97;
        ushort unsignedShortVariable = 52130;
        short shortVariable = -10000;
        uint unsignedIntVariable = 4825932;

        Console.WriteLine("Signed byte variable = {0}\nUnsigned byte variable = {1}\nUnsigned short variable = {2}" +
                "\nShort variable = {3}\nUnsigned integer variable = {4}",
                signedByteVariable, unsignedByteVariable, unsignedShortVariable, shortVariable, unsignedIntVariable);
    }
}
