namespace Banks.Library.Accounts
{
    using Banks.Library.Customers;

    /// <summary>
    /// Mortgage for individuals
    /// </summary>
    public class IndividualMortgage : Mortgage
    {
        public IndividualMortgage(string iban, Customer customer, decimal balance, decimal interestRate, uint discountMonths)
            : base(iban, customer, balance, interestRate, discountMonths)
        {
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