namespace Bank
{
    using System;

    public class Demo
    {
        static void Main(string[] args)
        {
            Console.Title = "Bank";

            Account[] accounts = {
                                     new MortgageAccount(Customer.Company, 20000, 4),
                                     new DepositAccount(Customer.Individual, 900, 2),
                                     new LoanAccount(Customer.Individual, 3000, 3)
                                 };
   
            foreach (var account in accounts)
            {
                Console.WriteLine("{0} {1}", account.GetType().Name, account.InterestAmountForPeriod(6));
            }

            Console.WriteLine();

            foreach (var account in accounts)
            {
                Console.WriteLine("{0} {1}", account.GetType().Name, account.InterestAmountForPeriod(24));
            }
        }
    }
}
