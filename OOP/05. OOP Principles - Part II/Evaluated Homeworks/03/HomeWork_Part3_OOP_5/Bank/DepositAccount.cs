using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public class DepositAccount : Account, IDraw
    {
        public DepositAccount(Customer customer, decimal balance, decimal intrestRate)
            : base(customer, balance, intrestRate)
        {
        }
      
        public override decimal CalculateIntrestForPeriodOfMonths(int months)
        {
            if (this.Balance < 1000)
            {
                return 0;
            }
            else
            {
                return months * IntrestRate * this.Balance;
            }
        }
        
        public void Draw(decimal amount) 
        {
            if (this.Balance < amount)
            {
                 throw new Exception("You don't have enough money.");
            }
            else if (amount < 0)
            {
                 throw new Exception("Can't draw negative amounts.");
            }
            else
            {
                this.Balance -= amount;
                Console.WriteLine("Succesfull money with draw");
            }
        }
    }
}
