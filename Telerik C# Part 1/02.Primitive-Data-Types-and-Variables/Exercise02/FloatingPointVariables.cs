using System;

    /*
        Which of the following values can be assigned to a variable of type float 
        and which to a variable of type double: 34.567839023, 12.345, 8923.1234857, 3456.091?
    */

class FloatingPointVariables
{
    static void Main(string[] args)
    {
        float floatVariable1 = 12.345f, floatVariable2 = 3456.091f;
        double doubleVariable1 = 34.567839023d, doubleVariable2 = 8923.1234857d;
        Console.WriteLine("Float variables : \n{0} {1}  \n\nDouble variables : \n{2} {3}",
            floatVariable1, floatVariable2, doubleVariable1, doubleVariable2);
    }

}
