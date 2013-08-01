

using System;

class ExchangeThreeBits
{
    // Condition: Write a program that exchanges bits 3, 4 and 5 with bits 24, 25 and 26 of given 32-bit unsigned integer.
    // Extra: The program is modified to enter the bit positions manually!!!

    static void Main()
    {
        uint uintNum = 0; // Number > 0
        uint mask = 0;
        uint lowBitsValues = 0;
        uint highBitsValues = 0;
        int lowBitsSet_StartPosition = 0;       // The start position of a
        int highBitsSet_StartPosition = 0;      // set (of 3 digits) from bits. (i.e.: 1 Set = 3 bits IN A ROW!)
        bool bitPositionsAreCorrect = false;

        Console.Write("Enter 1 number: ");
        uintNum = uint.Parse(Console.ReadLine());

        // Choose bits positions (do it until they are correct)
        do
        {
            Console.WriteLine("Define which bit values you want to exchange:");
            Console.WriteLine("P.S. To test the program with the original condition, please enter {0}" +
                "\"3\" for lower bits and \"24\" for higher bits. {1}", Environment.NewLine, Environment.NewLine);
            Console.Write("Enter the start position of the lower bits: ");
            lowBitsSet_StartPosition = int.Parse(Console.ReadLine());
            Console.Write("Enter the start position of the higher bits: ");
            highBitsSet_StartPosition = int.Parse(Console.ReadLine());

            // Check if positions will break the program
            if (((lowBitsSet_StartPosition + 3) > highBitsSet_StartPosition) || (lowBitsSet_StartPosition < 0) || (highBitsSet_StartPosition > 29))
            {
                Console.WriteLine("{0}You have entered wrong bits positions!!!", Environment.NewLine);
                Console.WriteLine("Positions must meet the CONDITIONS:");
                Console.WriteLine("\t1. Lower position + 3 <= Higher position");
                Console.WriteLine("\t2. Lower position >= 0");
                Console.WriteLine("\t3. Higer positions <= 29 {0}", Environment.NewLine);
            }
            else
            {
                bitPositionsAreCorrect = true;
            }
            // End check

        } while (bitPositionsAreCorrect == false);

        Console.WriteLine("{0}Binary code of the number: {1}", Environment.NewLine, Convert.ToString(uintNum, 2).PadLeft(32, '0'));
        Console.WriteLine("Take a look at those bits: {0}^^^{1}^^^ ",                   // To see easly which
            new string(' ', 29 - highBitsSet_StartPosition),                            // bits are going
            new string(' ', highBitsSet_StartPosition - lowBitsSet_StartPosition - 3)); // to be exchanged

        // Extract the lower bits
        mask = (uint)(7 << lowBitsSet_StartPosition);                   // Move the mask to the bit values that you want to extract  
        lowBitsValues = (uintNum & mask) >> lowBitsSet_StartPosition;   // Extract the bit values (3 digits)
        uintNum = uintNum & ~mask;                                      // Set the extracted bit values of the number to 0

        // Extract the higher bits
        mask = (uint)(7 << highBitsSet_StartPosition);                      // Move the mask to the bit values that you want to extract
        highBitsValues = (uintNum & mask) >> highBitsSet_StartPosition;     // Extract the bit values (3 digits)
        uintNum = uintNum & ~mask;                                          // Set the extracted bit values of the number to 0

        Console.WriteLine("{0}Values of the extracted lower bits: {1}", Environment.NewLine,
            Convert.ToString(lowBitsValues, 2).PadLeft(3, '0'));
        Console.WriteLine("Values of the extracted higher bits: {0}",
            Convert.ToString(highBitsValues, 2).PadLeft(3, '0'));

        // Exchange the lower and higher bit values in the number (uintNum)
        highBitsValues = highBitsValues << lowBitsSet_StartPosition;        // Move the high bits to the position of the low bits
        lowBitsValues = lowBitsValues << highBitsSet_StartPosition;         // Move the low bits to the position of the high bits  
        uintNum = (uintNum | lowBitsValues) | highBitsValues;               // Replace the number bits with the exchanged bits

        Console.WriteLine("{0}The number after exchanging it's bits {1}, {2}, {3} with bits {4}, {5}, {6}: ", Environment.NewLine,
            lowBitsSet_StartPosition, lowBitsSet_StartPosition + 1, lowBitsSet_StartPosition + 2,
            highBitsSet_StartPosition, highBitsSet_StartPosition + 1, highBitsSet_StartPosition + 2);
        Console.WriteLine("New number (decimal): {0}", uintNum);
        Console.WriteLine("New number (binary) : {0}", Convert.ToString(uintNum, 2).PadLeft(32, '0'));
        Console.WriteLine("They are exchanged! : {0}^^^{1}^^^ ",                        // To see easly which
            new string(' ', 29 - highBitsSet_StartPosition),                            // bits are going
            new string(' ', highBitsSet_StartPosition - lowBitsSet_StartPosition - 3)); // to be exchanged
        Console.WriteLine();
    }
}

