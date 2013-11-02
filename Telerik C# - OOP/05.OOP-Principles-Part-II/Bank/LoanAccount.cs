namespace Bank
{
    using System;

    public class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal balance, decimal interestRate) : base(customer, balance, interestRate)
        {
        }

        public override decimal InterestAmountForPeriod(short months)
        {
            if (customer == Customer.Individual)
            {
                months -= 3;
            }
            else
            {
                months -= 2;
            }

            if (months < 0)
            {
                return 0;
            }
            else
            {
                return months * interestRate;
            }
        }
    }
}
