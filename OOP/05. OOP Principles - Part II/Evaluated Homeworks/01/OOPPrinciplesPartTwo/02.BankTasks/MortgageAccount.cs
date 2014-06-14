using System;

class MortgageAccount : Account, IDepositable
{
    public MortgageAccount(Customer customer, double balance, double rate)
        : base(customer, balance, rate)
    {
    }

    public override double CalculateInterestRate(int months)
    {
        if (this.Customer == Customer.Company && months <= 12)
        {
            return base.CalculateInterestRate(months) / 2;
        }
        else if (this.Customer == Customer.Individual && months <= 6)
        {
            return 0;
        }
        else if (this.Customer == Customer.Company)
        {
            return base.CalculateInterestRate(12) / 2 + base.CalculateInterestRate(months - 12);
        }
        else
        {
            return base.CalculateInterestRate(months - 6);
        }
    }

    public void DepositMoney(double sum)
    {
        this.Balance += sum;
    }
}