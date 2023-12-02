public class SavingsAccount : Account
{
    private decimal interestRate;

    public SavingsAccount(string accountNumber, decimal interestRate)
        : base(accountNumber)
    {
        this.interestRate = interestRate;
    }

    public void CalculateInterest()
    {
        decimal interest = balance * interestRate;
        Deposit(interest);
        Console.WriteLine($"Interest calculated: {interest:C}");
    }

    public override void Withdraw(decimal amount)
    {
        if (balance >= amount)
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