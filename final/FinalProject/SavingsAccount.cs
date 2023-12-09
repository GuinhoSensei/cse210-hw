public class SavingsAccount : Account
{
    private decimal InterestRate;

    public SavingsAccount(string accountNumber, decimal interestRate)
        : base(accountNumber)
    {
        InterestRate = interestRate;
    }

    public void CalculateInterest()
    {
        decimal interest = Balance * InterestRate;
        Deposit(interest);
        Console.WriteLine($"{GetAccountType()} {AccountNumber} - Interest calculated: {interest:C}");
    }

    public override void Withdraw(decimal amount)
    {
        if (Balance >= amount)
        {
            Balance -= amount;
            Console.WriteLine($"{GetAccountType()} {AccountNumber} - Withdrawn {amount:C}. New balance: {Balance:C}");
        }
        else
        {
            Console.WriteLine($"{GetAccountType()} {AccountNumber} - Insufficient funds.");
        }
    }

    public override string GetAccountType()
    {
        return "Savings Account";
    }
}