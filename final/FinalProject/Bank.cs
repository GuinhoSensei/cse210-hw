public class Bank
{
    private List<Customer> customers;

    public Bank()
    {
        customers = new List<Customer>();
    }

    public void AddCustomer(Customer customer)
    {
        customers.Add(customer);
    }

    public Customer CreateCustomer(string name)
    {
        Customer customer = new Customer(name);
        AddCustomer(customer);
        return customer;
    }

    public void ProcessInterest()
    {
        foreach (var customer in customers)
        {
            foreach (var account in customer.GetAccounts())
            {
                if (account is SavingsAccount savingsAccount)
                {
                    savingsAccount.CalculateInterest();
                }
            }
        }
    }

    public List<Customer> GetCustomers()
    {
        return customers;
    }

    public Customer GetCustomerByName(string name)
    {
        return customers.Find(c => c.Name == name);
    }

    public Account GetAccountByNumber(string accountNumber)
    {
        foreach (var cust in customers)
        {
            var account = cust.GetAccountByNumber(accountNumber);
            if (account != null)
            {
                return account;
            }
        }
        return null;
    }

    public void MakeTransaction(Account account, decimal amount)
    {
        var transaction = new Transaction { Account = account, Amount = amount };
        transaction.ProcessTransaction();
    }
}