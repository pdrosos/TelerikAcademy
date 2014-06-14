/* A bank holds different types of accounts for its customers: deposit accounts, loan accounts and mortgage accounts. 
 * Customers could be individuals or companies. All accounts have customer, balance and interest rate (monthly based). 
 * Deposit accounts are allowed to deposit and with draw money. Loan and mortgage accounts can only deposit money. All 
 * accounts can calculate their interest amount for a given period (in months). In the common case its is calculated as 
 * follows: number_of_months * interest_rate. Loan accounts have no interest for the first 3 months if are held by 
 * individuals and for the first 2 months if are held by a company. Deposit accounts have no interest if their balance 
 * is positive and less than 1000. Mortgage accounts have ½ interest for the first 12 months for companies and no 
 * interest for the first 6 months for individuals. Your task is to write a program to model the bank system by classes 
 * and interfaces. You should identify the classes, interfaces, base classes and abstract actions and implement the 
 * calculation of the interest functionality through overridden methods.*/

using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("---Deposit Account---");
        DepositAccount depositAcc = new DepositAccount(Customer.Individual, 500, 5);
        depositAcc.DepositMoney(2000);
        Console.WriteLine("Balance after deposit 2000: {0}", depositAcc.Balance);
        Console.WriteLine("Interest rate: {0}", depositAcc.CalculateInterestRate(10));
        depositAcc.WithDrawMoney(2000);
        Console.WriteLine("Balance after withdraw 2000: {0}", depositAcc.Balance);
        Console.WriteLine("Interest rate: {0}", depositAcc.CalculateInterestRate(10));

        Console.WriteLine("\n---Loan Account---");
        LoanAccount loanAcc = new LoanAccount(Customer.Company, 1000, 5);
        loanAcc.DepositMoney(2000);
        Console.WriteLine("Balance after deposit 2000: {0}", loanAcc.Balance);
        Console.WriteLine("Interest rate: {0}", depositAcc.CalculateInterestRate(10));

        Console.WriteLine("\n---Mortgage Account---");
        MortgageAccount mortgageAccOne = new MortgageAccount(Customer.Company, 1000, 5);
        Console.WriteLine("Interest rate: {0}", mortgageAccOne.CalculateInterestRate(10));
        Console.WriteLine("Interest rate: {0}\n", mortgageAccOne.CalculateInterestRate(24));
        MortgageAccount mortgageAccTwo = new MortgageAccount(Customer.Individual, 1000, 5);
        Console.WriteLine("Interest rate: {0}", mortgageAccTwo.CalculateInterestRate(4));
        Console.WriteLine("Interest rate: {0}\n", mortgageAccTwo.CalculateInterestRate(10));
    }
}
