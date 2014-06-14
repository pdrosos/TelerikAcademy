namespace Banks.Library.Accounts
{
    public interface IDepositable
    {
        /// <summary>
        /// Deposit money
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>Current object for method chaining</returns>
        IDepositable DepositMoney(decimal amount);
    }
}
