namespace Banks.Library.Accounts
{
    using Banks.Library.Customers;

    /// <summary>
    /// Abstract loan
    /// </summary>
    public class Loan : Account, IDiscountable
    {
        protected uint discountMonths;

        public Loan(string iban, Customer customer, decimal balance, decimal interestRate, uint discountMonths)
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

        /// <summary>
        /// Calculates interest
        /// No interest for the first discountMonths months
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public override decimal CalculateInterest(uint months)
        {
            if (months <= this.discountMonths)
            {
                return 0;
            }

            return base.CalculateInterest(months - this.discountMonths);
        }
    }
}