public class Transaction
{
    public Account Account { get; set; }
    public decimal Amount { get; set; }

    public void ProcessTransaction()
    {
        Account.Withdraw(Amount);
        Console.WriteLine("Processing transaction...");
    }
}
