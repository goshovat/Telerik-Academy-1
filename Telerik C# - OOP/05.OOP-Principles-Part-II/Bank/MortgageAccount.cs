namespace Bank
{
    using System;

    public class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
        }

        public override decimal InterestAmountForPeriod(short mounts)
        {
            if (customer == Customer.Individual)
            {
                if (mounts <= 6)
                {
                    return 0;
                }
                else
                {
                    return interestRate * (mounts - 6);
                }
            }
            else
            {
                if (mounts <= 12)
                {
                    return (interestRate * mounts) / 2;
                }
                else
                {
                    return (interestRate * 12) / 2 + interestRate * (mounts - 12);
                }
            }
        }
    }
}
