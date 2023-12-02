public class FixedDepositAccount : Account
{
    private DateTime maturityDate;

    public FixedDepositAccount(string accountNumber, DateTime maturityDate)
        : base(accountNumber)
    {
        this.maturityDate = maturityDate;
    }

    public override void Withdraw(decimal amount)
    {
        if (DateTime.Now < maturityDate)
        {
            Console.WriteLine("Cannot withdraw from a fixed deposit account before maturity date.");
        }
        else if (balance >= amount)
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