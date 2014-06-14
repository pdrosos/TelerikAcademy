namespace Banks.Library.Accounts
{
    using Banks.Library.Customers;

    /// <summary>
    /// Abstract mortgage
    /// </summary>
    public abstract class Mortgage : Account, IDiscountable
    {
        protected uint discountMonths;

        public Mortgage(string iban, Customer customer, decimal balance, decimal interestRate, uint discountMonths)
            : base(iban, customer, balance, interestRate)
        {
            this.DiscountMonths = discountMonths;
        }

        public uint DiscountMonths
        {
            get
            {
                return this.discountMonths;
            }
            set
            {
                this.discountMonths = value;
            }
        }
    }
}