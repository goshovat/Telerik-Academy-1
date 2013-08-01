using System;

/*
    Write a program that, depending on the user's choice inputs int, double or string variable. 
    If the variable is integer or double, increases it with 1. 
    If the variable is string, appends "*" at its end. 
    The program must show the value of that variable as a console output. Use switch statement.
*/

class SwitchVariable
{
    static void Main(string[] args)
    {
        Console.Title = "Switch variable";
        string varibale;
        Console.Write("Which type of variable you want to enter (int, double, string) : ");
        varibale = Console.ReadLine();

        switch (varibale)
        {
            case "int":
                Console.Write("Enter the int variable : ");
                int intVariable = int.Parse(Console.ReadLine());
                intVariable += 1;
                Console.WriteLine("The new value of the variable is {0}", intVariable);
                break;
            case "double":
                Console.Write("Enter the double variable : ");
                double doubleVariable = double.Parse(Console.ReadLine());
                doubleVariable += 1;
                Console.WriteLine("The new value of the variable is {0}", doubleVariable);
                break;
            case "string":
                Console.Write("Enter the string variable : ");
                string stringVariable = Console.ReadLine();
                stringVariable = stringVariable + "*";
                Console.WriteLine("The new value of the variable is : {0}", stringVariable);
                break;
            default:
                Console.WriteLine("You have entered a wrong type of the variable!!!");
                break;
        }
    }
}