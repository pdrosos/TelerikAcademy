namespace Banks.Library.Accounts
{
    using System;
    using System.Text;
    using Banks.Library.Customers;

    /// <summary>
    /// Abstract account
    /// </summary>
    public abstract class Account : IDepositable
    {
        protected string iban;
        protected Customer owner;
        protected decimal balance;
        protected decimal interestRate;

        public Account(string iban, Customer owner, decimal balance, decimal interestRate)
        {
            this.Iban = iban;
            this.owner = owner;
            owner.Accounts.Add(this);
            this.Balance = balance;
            this.InterestRate = interestRate;
        }

        public string Iban
        {
            get
            {
                return this.iban;
            }
            set
            {
                this.iban = value;
            }
        }

        public Customer Owner
        {
            get
            {
                return this.owner;
            }
            set
            {
                this.owner.Accounts.Remove(this);
                this.owner = value;
                this.owner.Accounts.Add(this);
            }
        }

        public decimal Balance
        {
            get
            {
                return this.balance;
            }
            set
            {
                this.balance = value;
            }
        }

        public decimal InterestRate
        {
            get
            {
                return this.interestRate;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Interest rate can not be less than zero");
                }

                this.interestRate = value;
            }
        }

        /// <summary>
        /// Deposit money
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>Current object for method chaining</returns>
        public IDepositable DepositMoney(decimal amount)
        {
            this.Balance += amount;

            return this;
        }

        /// <summary>
        /// Calculates interest via a generic formula. This method can be overriden by all conctete successors.
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public virtual decimal CalculateInterest(uint months)
        {
            return this.Balance * this.InterestRate * months;
        }

        /// <summary>
        /// Account information
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append("Type: ").AppendLine(this.GetType().ToString());
            info.Append("IBAN: ").AppendLine(this.Iban);
            info.Append("Owner: ").Append(this.Owner);            
            info.Append("Balance: ").AppendLine(this.Balance.ToString());
            info.Append("Interest rate: ").AppendLine(this.InterestRate.ToString());

            return info.ToString();
        }
    }
}
