using System;
    /*
        A bank account has a holder name (first name, middle name and last name), available amount of money (balance), 
        bank name, IBAN, BIC code and 3 credit card numbers associated with the account. 
        Declare the variables needed to keep the information for a single bank account using the appropriate data types
        and descriptive names.
    */
class BankAccount
{
    static void Main(string[] args)
    {
        string firstName;
        string middleName;
        string lastName;
        float balance;
        string bankName;
        string IBAN;
        string BIC;
        long[] cardNumber = new long[3];
        Console.Write("Enter your first name : ");
        firstName = Console.ReadLine();
        Console.Write("Enter your middle name : ");
        middleName = Console.ReadLine();
        Console.Write("Enter your last name : ");
        lastName = Console.ReadLine();
        Console.Write("Enter your balance : ");
        balance = float.Parse(Console.ReadLine());
        Console.Write("Enter bank name : ");
        bankName = Console.ReadLine();
        Console.Write("Enter your IBAN : ");
        IBAN = Console.ReadLine();
        Console.Write("Enter BIC : ");
        BIC = Console.ReadLine();
        for (int i = 0; i < 3; i++)
        {
            Console.Write("Enter card №{0} number  : ", i + 1);
            cardNumber[i] = long.Parse(Console.ReadLine());
        }
        Console.WriteLine("\nName - {0} {1} {2} ", firstName, middleName, lastName);
        Console.WriteLine("Balance - {0}", balance);
        Console.WriteLine("Bank name - {0}", bankName);
        Console.WriteLine("IBAN - {0}", IBAN);
        Console.WriteLine("BIC - {0}", BIC);
        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine("Card №{0} number - {1} ", i + 1, cardNumber[i]);
        }
    }
}
