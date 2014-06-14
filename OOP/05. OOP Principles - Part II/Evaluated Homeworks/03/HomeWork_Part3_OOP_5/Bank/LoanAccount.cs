using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class LoanAccount : Account
    {
        public LoanAccount(Customer customer, decimal balance, decimal intrestRate)
            : base(customer, balance, intrestRate)
        {

        }

        public override decimal CalculateIntrestForPeriodOfMonths(int months)
        {
            if (months < 0)
            {
                throw new Exception("Months can't be negative number.");
            }
            else if (this.Customer is Individual && months <= 3)
            {
                return 0;
            }
            else if (this.Customer is Company && months <= 2)
            {
                return 0;
            }
            else
            {
                return months * this.IntrestRate * this.Balance;
            }
        }
      
    }
}
