using System;

abstract class Account
{
    private Customer customer;
    private double balance;
    private double rate;

    public Account(Customer customer, double balance, double rate)
    {
        this.customer = customer;
        this.balance = balance;
        this.rate = rate;
    }

    public Customer Customer
    {
        get { return this.customer; }
        set { this.customer = value; }
    }

    public double Balance
    {
        get { return this.balance; }
        set { this.balance = value; }
    }

    public double Rate
    {
        get { return this.rate; }
        set
        {
            if (rate <= 0)
            {
                throw new ArgumentException("Invalid rate!");
            }
            this.rate = value;
        }
    }

    public virtual double CalculateInterestRate(int months)
    {
        return this.Rate * months;
    }
}
