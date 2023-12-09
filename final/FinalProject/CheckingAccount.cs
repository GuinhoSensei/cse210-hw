public class CheckingAccount : Account
{
    private decimal OverdraftLimit;

    public CheckingAccount(string accountNumber, decimal overdraftLimit)
        : base(accountNumber)
    {
        OverdraftLimit = overdraftLimit;
    }

    public override void Withdraw(decimal amount)
    {
        if (Balance + OverdraftLimit >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"{GetAccountType()} {AccountNumber} - Deposited {amount:C}. New balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine($"{GetAccountType()} {AccountNumber} - Insufficient funds.");
        }
    }

    public override string GetAccountType()
    {
        return "Checking Account";
    }
}