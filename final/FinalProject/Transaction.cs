public class Transaction
{
    public void ProcessTransaction(Account account, decimal amount)
    {
        account.Withdraw(amount);
    }
}