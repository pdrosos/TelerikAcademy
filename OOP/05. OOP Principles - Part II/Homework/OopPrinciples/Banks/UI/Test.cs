namespace Banks.UI
{
    using System;
    using Banks.Library;
    using Banks.Library.Customers;
    using Banks.Library.Accounts;

    class Test
    {
        static void Main(string[] args)
        {
            // create a bank
            Bank bank = new Bank();

            // create some customers
            Individual person = new Individual("Pesho", "Peshev", "1111111111");
            Company company = new Company("Pesho OOD", "1231231231");
            bank.AddCustomer(person);
            bank.AddCustomer(company);

            // create some accounts for the customers
            Account personalDeposit = AccountFactory.CreateAccount(AccountType.Deposit, "AA00AAAA1231234", person, 1000m, 0.045m);
            bank.AddAccount(personalDeposit);
            // deposit money
            person.DepositMoney(personalDeposit, 500);

            Account personalLoan = AccountFactory.CreateAccount(AccountType.Loan, "BB00BBBB1231234", person, 2000m, 0.065m);
            bank.AddAccount(personalLoan);

            Account personalMortgage = AccountFactory.CreateAccount(AccountType.Mortgage, "CC00CCCC1231234", person, 10000m, 0.075m);
            bank.AddAccount(personalMortgage);

            Account companyDeposit = AccountFactory.CreateAccount(AccountType.Deposit, "DD00DDDD1231234", company, 15000m, 0.055m);
            bank.AddAccount(companyDeposit);
            // withdraw money
            company.WithdrawMoney((IWithdrawable)companyDeposit, 1000);

            Account companyLoan = AccountFactory.CreateAccount(AccountType.Loan, "EE00EEEE1231234", company, 20000m, 0.075m);
            bank.AddAccount(companyLoan);

            Account companyMortgage = AccountFactory.CreateAccount(AccountType.Mortgage, "FF00FFFF1231234", company, 50000m, 0.085m);
            bank.AddAccount(companyMortgage);

            // print information about customers and their accounts
            foreach (Customer customer in bank.Customers)
            {
                Console.WriteLine(customer);
                Console.WriteLine("-------------------------");
                Console.WriteLine();
                foreach (Account account in customer.Accounts)
                {
                    Console.WriteLine(account);
                    Console.WriteLine("Interest for 2 months: " + account.CalculateInterest(2));
                    Console.WriteLine("Interest for 14 months: " + account.CalculateInterest(14));
                    Console.WriteLine("-------------------------");
                    Console.WriteLine();
                }

                Console.WriteLine("=========================");
                Console.WriteLine();
            }


        }
    }
}
