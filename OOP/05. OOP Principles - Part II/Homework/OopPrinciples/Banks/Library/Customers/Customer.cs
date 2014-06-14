namespace Banks.Library.Customers
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using Banks.Library.Accounts;

    /// <summary>
    /// Abstract customer
    /// </summary>
    public abstract class Customer
    {
        protected List<Account> accounts = new List<Account>();

        public List<Account> Accounts
        {
            get
            {
                return this.accounts;
            }
        }

        /// <summary>
        /// Adds a new bank account
        /// </summary>
        /// <param name="account"></param>
        public void AddAccount(Account account)
        {
            this.accounts.Add(account);
        }

        /// <summary>
        /// Removes a bank account
        /// </summary>
        /// <param name="account"></param>
        public void RemoveAccount(Account account)
        {
            this.accounts.Remove(account);
        }

        /// <summary>
        /// Deposit money
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public IDepositable DepositMoney(IDepositable account, decimal amount)
        {
            return account.DepositMoney(amount);
        }

        /// <summary>
        /// Withdraw money
        /// </summary>
        /// <param name="account"></param>
        /// <param name="amount"></param>
        /// <returns></returns>
        public IWithdrawable WithdrawMoney(IWithdrawable account, decimal amount)
        {
            return account.WithdrawMoney(amount);
        }

        /// <summary>
        /// Customer information
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            StringBuilder info = new StringBuilder();

            info.Append("Type: ").AppendLine(this.GetType().ToString());

            return info.ToString();
        }
    }
}
