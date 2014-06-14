namespace Banks.Library.Accounts
{
    using System;
    using Banks.Library.Customers;
    using Banks.Library.Accounts.Exceptions;

    /// <summary>
    /// Deposit
    /// </summary>
    public class Deposit : Account, IWithdrawable
    {
        public Deposit(string iban, Customer customer, decimal balance, decimal interestRate)
            : base(iban, customer, balance, interestRate)
        {
        }

        /// <summary>
        /// Withdraw money
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>Current object for method chaining</returns>
        public IWithdrawable WithdrawMoney(decimal amount)
        {
            if (this.Balance < amount)
            {
                throw new InsufficientBalanceException(this.Balance, amount);
            }

            this.Balance -= amount;

            return this;
        }

        /// <summary>
        /// Calculates interest
        /// No interest if the balance is less than 1000
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public override decimal CalculateInterest(uint months)
        {
            if (this.Balance < 1000)
            {
                return 0;
            }

            return base.CalculateInterest(months);
        }
    }
}