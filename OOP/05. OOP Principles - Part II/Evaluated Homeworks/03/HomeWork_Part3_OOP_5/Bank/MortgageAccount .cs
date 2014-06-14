using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class MortgageAccount : Account
    {
        public MortgageAccount(Customer customer, decimal balance, decimal intrestRate)
            : base(customer, balance, intrestRate){}

        public override decimal CalculateIntrestForPeriodOfMonths(int months)
        {
            if (months < 0)
            {
                throw new Exception("Moths can't be negative.");
            }
            else if (this.Customer is Company && months > 12)
            {
                //Using temp to calculate intrest for the first 12 moths. 
                decimal temp = this.IntrestRate;
                temp += (this.IntrestRate / 2) * 12 * this.Balance;
              
                //After 12 moths continue normal calculation + first 12 months amount.
                months -= 12;
                return temp + (months * this.Balance * this.IntrestRate);
            }
            else if (this.Customer is Company && months <= 12)
            {
                return (this.IntrestRate / 2) * months * this.Balance;
            }
            else if (this.Customer is Individual && months > 6)
            {
                months -= 6;
                return this.IntrestRate * months * this.Balance;
            }
            else if (this.Customer is Individual && months <= 6)
            {
                return 0;
            }
            else
            {
                throw new Exception("Unknown error occurred");
            }
        }
    }
}
