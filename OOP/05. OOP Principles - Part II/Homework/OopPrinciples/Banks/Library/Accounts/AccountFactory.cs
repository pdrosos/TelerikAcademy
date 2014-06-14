namespace Banks.Library.Accounts
{
    using Banks.Library.Customers;
    using Banks.Library.Accounts.Exceptions;

    /// <summary>
    /// Creates a new account for a customer
    /// </summary>
    public static class AccountFactory
    {
        /// <summary>
        /// Creates a new account for a customer according to its type
        /// </summary>
        /// <param name="accountType"></param>
        /// <param name="iban"></param>
        /// <param name="customer"></param>
        /// <param name="balance"></param>
        /// <param name="interestRate"></param>
        /// <returns></returns>
        public static Account CreateAccount(AccountType accountType, string iban, Customer customer, decimal balance, decimal interestRate)
        {
            if (accountType == AccountType.Deposit)
            {
                return new Deposit(iban, customer, balance, interestRate);
            }

            if (accountType == AccountType.Mortgage)
            {
                if (customer is Individual)
                {
                    return new IndividualMortgage(iban, customer, balance, interestRate, 6);
                }

                if (customer is Company)
                {
                    return new CompanyMortgage(iban, customer, balance, interestRate, 12);
                }
            }

            if (accountType == AccountType.Loan)
            {
                if (customer is Individual)
                {
                    return new Loan(iban, customer, balance, interestRate, 3);
                }

                if (customer is Company)
                {
                    return new Loan(iban, customer, balance, interestRate, 2);
                }
            }

            throw new UnknownAccountTypeException(accountType, customer);
        }
    }
}