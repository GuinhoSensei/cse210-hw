public abstract class Account
{
    private string accountNumber;
    protected decimal balance;

    public Account(string accountNumber)
    {
        this.accountNumber = accountNumber;
        balance = 0;
    }

    public string GetAccountNumber()
    {
        return accountNumber;
    }

    public decimal GetBalance()
    {
        return balance;
    }

    public virtual void Deposit(decimal amount)
    {
        balance += amount;
        Console.WriteLine($"Deposited {amount:C}. New balance: {balance:C}");
    }

    public abstract void Withdraw(decimal amount);
}