public class Customer
{
    private string name;
    private List<Account> accounts;

    public Customer(string name)
    {
        this.name = name;
        accounts = new List<Account>();
    }

    public void AddAccount(Account account)
    {
        accounts.Add(account);
        Console.WriteLine($"{name} added account {account.GetAccountNumber()}");
    }
}