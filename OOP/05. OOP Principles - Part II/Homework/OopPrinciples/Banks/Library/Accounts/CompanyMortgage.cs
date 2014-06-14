namespace Banks.Library.Accounts
{
    using Banks.Library.Customers;

    /// <summary>
    /// Mortgage for companies
    /// </summary>
    public class CompanyMortgage : Mortgage
    {
        public CompanyMortgage(string iban, Customer customer, decimal balance, decimal interestRate, uint discountMonths)
            : base(iban, customer, balance, interestRate, discountMonths)
        {
        }

        /// <summary>
        /// Calculates interest
        /// 1/2 interest for the first discountMonths months
        /// </summary>
        /// <param name="months"></param>
        /// <returns></returns>
        public override decimal CalculateInterest(uint months)
        {
            if (months <= this.discountMonths)
            {
                return base.CalculateInterest(months) / 2;
            }

            decimal interest = (base.CalculateInterest(this.discountMonths) / 2) + base.CalculateInterest(months - this.discountMonths);

            return interest;
        }
    }
}