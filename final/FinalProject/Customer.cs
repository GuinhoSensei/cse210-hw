
public class Customer
{
    public string Name { get; private set; }
    private List<Account> Accounts;

    public Customer(string name)
    {
        Name = name;
        Accounts = new List<Account>();
    }

    public void AddAccount(Account account)
    {
        Accounts.Add(account);
        Console.WriteLine($"{Name} added {account.GetAccountType()} {account.GetAccountNumber()}");
    }

    public List<Account> GetAccounts()
    {
        return Accounts;
    }

    public Account GetAccountByNumber(string accountNumber)
    {
        return Accounts.Find(account => account.GetAccountNumber() == accountNumber);
    }
}