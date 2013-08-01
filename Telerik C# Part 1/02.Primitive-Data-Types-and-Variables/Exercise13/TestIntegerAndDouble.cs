using System;
    /*
        Create a program that assigns null values to an integer and to double variables. 
        Try to print them on the console, try to add some values or the null literal to them and see the result.
    */
class TestIntegerAndDouble
{
    static void Main(string[] args)
    {
        int? testInt = null;
        double? testDouble = null;
        Console.WriteLine("Test 1 (assigned the int and double with \"null\" values) \nint - {0} \ndouble - {1}", testInt, testDouble);
        testInt += 4;
        testDouble += null;
        Console.WriteLine("\nTest 2 (added \"4\" to int and \"null\" to double) \nint - {0} \ndouble - {1} ", testInt, testDouble);
        testInt += null;
        testDouble += 5.323d;
        Console.WriteLine("\nTest 3 (added \"null\" to int nad \"5.323d\" to double) \nint - {0} \ndouble - {1} ", testInt, testDouble);
    }
}

