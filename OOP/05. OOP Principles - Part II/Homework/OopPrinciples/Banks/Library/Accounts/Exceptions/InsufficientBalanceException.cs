namespace Banks.Library.Accounts.Exceptions
{
    using System;

    class InsufficientBalanceException : ApplicationException
    {
        protected readonly decimal balance;
        protected readonly decimal amount;

        public InsufficientBalanceException(decimal balance, decimal amount)
        {
            this.balance = balance;
            this.amount = amount;
        }

        public override string Message
        {
            get
            {
                return string.Format("Insufficient balance to complete this operation. Balance: {0}, amount: {1}", this.balance, this.amount);
            }
        }
    }
}
