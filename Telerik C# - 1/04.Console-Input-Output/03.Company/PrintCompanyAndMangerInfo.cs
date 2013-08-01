using System;

/*
    A company has name, address, phone number, fax number, web site and manager. 
    The manager has first name, last name, age and a phone number. 
    Write a program that reads the information about a company and its manager and prints them on the console.
*/

class PrintCompanyAndMangerInfo
{
    static void Main(string[] args)
    {
        Console.Title = "Print company and manager information";

        Console.WriteLine("Entering the company's information");
        Console.WriteLine(new string('-', 60));
        Console.Write("Please, enter the company name : ");
        string companyName = Console.ReadLine();

        Console.Write("Please, enter the address of the company : ");
        string companyAddress = Console.ReadLine();

        Console.Write("Please, enter the company's phone number : ");
        long companyPhoneNumber = long.Parse(Console.ReadLine());

        Console.Write("Please, enter the company's fax number : ");
        long companyFaxNumber = long.Parse(Console.ReadLine());

        Console.Write("Please, enter the web site of the company : ");
        string companyWebSite = Console.ReadLine();

        Console.WriteLine(new string('-', 60));
        Console.WriteLine("\nEntering the manager's information");
        Console.WriteLine(new string('-', 60));
        Console.Write("Please, enter the first name of the manager : ");
        string managerFirstName = Console.ReadLine();

        Console.Write("Please, enter the second name of the manager : ");
        string managerSecondName = Console.ReadLine();

        Console.Write("Please, enter the age of the manager : ");
        byte managerAge = byte.Parse(Console.ReadLine());

        Console.Write("Please, enter the manager's phone number : ");
        long mangerPhoneNumber = long.Parse(Console.ReadLine());
        Console.WriteLine(new string('-', 60));

        Console.WriteLine("\nCompany's information");
        Console.WriteLine(new string('-', 40));
        Console.WriteLine(" Name : {0}\n Address : {1}\n Phone number : {3}\n Fax number : {4}\n Web site : {5}",
            companyName, companyAddress, companyPhoneNumber, companyPhoneNumber, companyFaxNumber, companyWebSite);
        Console.WriteLine(new string('-', 40));
        Console.WriteLine("\nManager's information");
        Console.WriteLine(new string('-', 40));
        Console.WriteLine(" Name : {0} {1}\n Age : {2}\n Phone number : {3}",
            managerFirstName, managerSecondName, managerAge, mangerPhoneNumber);
        Console.WriteLine(new string('-', 40) + "\n");
    }
}