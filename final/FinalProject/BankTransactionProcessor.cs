public class BankTransactionProcessor
{
    public void ProcessTransactions(List<Transaction> transactions)
    {
        foreach (var transaction in transactions)
        {
            transaction.ProcessTransaction();
        }
    }
}
