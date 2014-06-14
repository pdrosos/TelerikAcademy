using System;

class DepositAccount : Account, IDepositable, IWithDrawable
{
    public DepositAccount(Customer customer, double balance, double rate)
        : base(customer, balance, rate)
    {
    }

    public override double CalculateInterestRate(int months)
    {
        if (this.Balance <= 1000)
        {
            return 0;
        }
        else
        {
           return base.CalculateInterestRate(months);
        }
    }

    public void DepositMoney(double sum)
    {
        this.Balance += sum;
    }

    public void WithDrawMoney(double sum)
    {
        this.Balance -= sum;
    }
}
