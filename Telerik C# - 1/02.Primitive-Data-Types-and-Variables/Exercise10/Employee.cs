using System;
    /*
        A marketing firm wants to keep record of its employees. 
        Each record would have the following characteristics – first name, 
        family name, age, gender (m or f), ID number, unique employee number (27560000 to 27569999). 
        Declare the variables needed to keep the information for a single employee using appropriate data types
        and descriptive names.
    */
class Employee
{
    static void Main(string[] args)
    {
        string firstName;
        string familyName;
        byte age;
        char gender;
        ushort idNumber;
        uint employeeNumber;
        Console.Write("Enter your first name : ");
        firstName = Console.ReadLine();
        Console.Write("Enter your family name : ");
        familyName = Console.ReadLine();
        Console.Write("Enter your age : ");
        age = byte.Parse(Console.ReadLine());
        Console.Write("Enter your gender (m or f) : ");
        gender = char.Parse(Console.ReadLine());
        Console.Write("Enter your ID number : ");
        idNumber = ushort.Parse(Console.ReadLine());
        Console.WriteLine("Enter your empolyee number (from 27560000 to 27569999) : ");
        employeeNumber = uint.Parse(Console.ReadLine());
        Console.WriteLine("\nName - {0} {1}", firstName, familyName);
        Console.WriteLine("Age - {0}", age);
        if (gender.Equals('m'))
        {
            Console.WriteLine("Gender - male");
        }
        else if (gender.Equals('f'))
        {
            Console.WriteLine("Gender - female");
        }
        else
        {
            Console.WriteLine("Gender - unknown");
        }
        Console.WriteLine("ID number - {0}", idNumber);
        Console.WriteLine("Employee number - {0}", employeeNumber);
    }
}