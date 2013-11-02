using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class DepositAccount : Account, IWithDrawable
    {
        public DepositAccount(Customer customer, decimal balance, decimal interestRate) 
            : base(customer, balance, interestRate)
        {
        }

        public void Withdraw(decimal money)
        {
            this.Balance -= money;
        }

        public override decimal InterestAmountForPeriod(short months)
        {
            if (balance > 0 && balance < 1000)
            {
                return 0;
            }

            return months * interestRate;
        }
    }
}
