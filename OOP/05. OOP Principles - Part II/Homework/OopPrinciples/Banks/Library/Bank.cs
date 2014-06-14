namespace Banks.Library
{
    using System;
    using System.Collections.Generic;
    using Banks.Library.Accounts;
    using Banks.Library.Customers;

    /// <summary>
    /// Bank
    /// </summary>
    public class Bank
    {
        protected List<Customer> customers;
        protected List<Account> accounts;

        public Bank()
        {
            this.customers = new List<Customer>();
            this.accounts = new List<Account>();
        }

        public List<Customer> Customers
        {
            get
            {
                return this.customers;
            }
        }

        public List<Account> Accounts
        {
            get
            {
                return this.accounts;
            }
        }

        /// <summary>
        /// Adds a new customer
        /// </summary>
        /// <param name="customer"></param>
        public void AddCustomer(Customer customer)
        {
            this.customers.Add(customer);
        }

        /// <summary>
        /// Removes a customer
        /// </summary>
        /// <param name="customer"></param>
        public void RemoveCustomer(Customer customer)
        {
            this.customers.Remove(customer);
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
    }
}
