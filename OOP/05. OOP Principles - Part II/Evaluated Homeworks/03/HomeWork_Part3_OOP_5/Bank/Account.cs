using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank
{
    public abstract class Account
    {
        //Filds
        private Customer customer;
        private decimal balance;
        private decimal intrestRate;

        //Properties
        public Customer Customer 
        {
            get { return this.customer; }
        }
        public decimal Balance
        {
            get { return this.balance; }
            set { this.balance = value; }   
        }
        public decimal IntrestRate 
        {
            get { return this.intrestRate; }
        }

        //Constructor
        public Account(Customer customer, decimal balance, decimal intrestRate) 
        {
            this.customer = customer;
            this.balance = balance;
            this.intrestRate = intrestRate / 100;
        }

        //Virtual methods
        public virtual decimal CalculateIntrestForPeriodOfMonths(int months) 
        {
            if (months < 0)
            {
                throw new Exception("Months can't be negative number.");
            }
            return this.intrestRate * months;
        }

        //Methods that are the same for all accounts.
        public void Deposit(decimal money)
        {
            if (money < 0)
            {
                throw new Exception("Can't deposit negative amounts.");
            }
            this.Balance += money;
        }
        
    }
}
