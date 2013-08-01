using System;

/*
    Declare two string variables and assign them with “Hello” and “World”. 
    Declare an object variable and assign it with the concatenation of the first two variables (mind adding an interval). 
    Declare a third string variable and initialize it with the value of the object variable (you should perform type casting).
*/

class StringVaribles
{
    static void Main(string[] args)
    {
        string hello = "Hello";
        string world = "World";
        object concatStrings = hello + " " + world;
        string helloWorld = (string)concatStrings;
        Console.WriteLine("First string is - {0}. \nSecond string is - {1}. \nThird (concatenated) string is - {2}.",
            hello, world, helloWorld);
    }
}

