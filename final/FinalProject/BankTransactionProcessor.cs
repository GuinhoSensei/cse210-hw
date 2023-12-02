public class BankTransactionProcessor
{
    public void ProcessTransactions(List<Transaction> transactions)
    {
        foreach (var transaction in transactions)
        {
            Console.WriteLine("Processing a transaction...");
        }
    }
}