public class FixedDepositAccount : Account
{
    private DateTime MaturityDate;

    public FixedDepositAccount(string accountNumber, DateTime maturityDate)
        : base(accountNumber)
    {
        MaturityDate = maturityDate;
    }

    public override void Withdraw(decimal amount)
    {
        if (DateTime.Now < MaturityDate)
        {
            Console.WriteLine($"{GetAccountType()} {AccountNumber} - Cannot withdraw from a fixed deposit account before maturity date.");
        }
        else if (Balance >= amount)
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
        return "Fixed Deposit Account";
    }
}