public class CheckingAccount : Account
{
    private decimal overdraftLimit;

    public CheckingAccount(string accountNumber, decimal overdraftLimit)
        : base(accountNumber)
    {
        this.overdraftLimit = overdraftLimit;
    }

    public override void Withdraw(decimal amount)
    {
        if (balance + overdraftLimit >= amount)
        {
            balance -= amount;
            Console.WriteLine($"Withdrawn {amount:C}. New balance: {balance:C}");
        }
        else
        {
            Console.WriteLine("Insufficient funds.");
        }
    }
}