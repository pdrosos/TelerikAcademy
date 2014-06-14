using System;

class LoanAccount : Account, IDepositable
{
    public LoanAccount(Customer customer, double balance, double rate)
        : base(customer, balance, rate)
    {
    }

    public override double CalculateInterestRate(int months)
    {
        if (this.Customer == Customer.Individual)
        {
            months -= 3;
        }
        else
        {
            months -= 2;
        }
        if (months > 0)
        {
            return base.CalculateInterestRate(months);
        }
        else
        {
            return 0;
        }
    }

    public void DepositMoney(double sum)
    {
        this.Balance += sum;
    }
}
