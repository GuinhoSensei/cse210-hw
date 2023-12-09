public abstract class Account
{
    protected string AccountNumber;
    protected decimal Balance;

    public Account(string accountNumber)
    {
        AccountNumber = accountNumber;
        Balance = 0;
    }

    public string GetAccountNumber()
    {
        return AccountNumber;
    }

    public decimal GetBalance()
    {
        return Balance;
    }

    public virtual void Deposit(decimal amount)
    {
        Balance += amount;
        Console.WriteLine($"{GetAccountType()} {AccountNumber} - Deposited {amount:C}. New balance: {Balance:C}");
    }

    public abstract void Withdraw(decimal amount);

    public virtual string GetAccountType()
    {
        return "Account";
    }
}