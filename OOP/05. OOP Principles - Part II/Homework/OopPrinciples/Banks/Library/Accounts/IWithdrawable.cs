namespace Banks.Library.Accounts
{
    public interface IWithdrawable
    {
        /// <summary>
        /// Withdraw money
        /// </summary>
        /// <param name="amount"></param>
        /// <returns>Current object for method chaining</returns>
        IWithdrawable WithdrawMoney(decimal amount);
    }
}
