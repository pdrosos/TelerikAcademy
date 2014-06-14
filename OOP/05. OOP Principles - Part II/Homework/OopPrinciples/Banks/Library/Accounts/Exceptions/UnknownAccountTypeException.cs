namespace Banks.Library.Accounts.Exceptions
{
    using System;
    using Banks.Library.Customers;

    class UnknownAccountTypeException : ApplicationException
    {
        protected readonly AccountType accountType;
        protected readonly Customer customer;

        public UnknownAccountTypeException(AccountType accountType, Customer customer)
        {
            this.accountType = accountType;
            this.customer = customer;
        }

        public override string Message
        {
            get
            {
                return string.Format("Unable to create an account. Account type: {0}, customer: {1}", 
                    this.accountType, this.customer);
            }
        }
    }
}
