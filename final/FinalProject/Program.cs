class Program
{
    static void Main()
    {
        Bank bank = new Bank();

        while (true)
        {
            Console.WriteLine("1. Create Customer");
            Console.WriteLine("2. Create Account");
            Console.WriteLine("3. Make Transaction");
            Console.WriteLine("4. Process Transactions");
            Console.WriteLine("5. Exit");

            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    CreateCustomer(bank);
                    break;

                case "2":
                    CreateAccount(bank);
                    break;

                case "3":
                    MakeTransaction(bank);
                    break;

                case "4":
                    bank.ProcessInterest();
                    break;

                case "5":
                    Console.WriteLine("Exiting program. Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Please enter a valid option.");
                    break;
            }
        }
    }

    static void CreateCustomer(Bank bank)
    {
        Console.Write("Enter Customer Name: ");
        string name = Console.ReadLine();
        bank.CreateCustomer(name);
    }

    static void CreateAccount(Bank bank)
    {
        Console.WriteLine("Select Customer:");

        foreach (var newcustomer in bank.GetCustomers())
        {
            Console.WriteLine($"{newcustomer.Name}");
        }

        Console.Write("Enter Customer Name: ");
        string customerName = Console.ReadLine();

        var customer = bank.GetCustomerByName(customerName);

        if (customer == null)
        {
            Console.WriteLine("Customer not found. Please create a customer first.");
            return;
        }

        Console.WriteLine("Select Account Type:");
        Console.WriteLine("1. Savings Account");
        Console.WriteLine("2. Checking Account");
        Console.WriteLine("3. Fixed Deposit Account");

        Console.Write("Enter your choice: ");
        string accountChoice = Console.ReadLine();

        Console.Write("Enter Account Number: ");
        string accountNumber = Console.ReadLine();

        switch (accountChoice)
        {
            case "1":
                customer.AddAccount(new SavingsAccount(accountNumber, 0.05m));
                break;

            case "2":
                customer.AddAccount(new CheckingAccount(accountNumber, 100));
                break;

            case "3":
                Console.Write("Enter Maturity Date (yyyy-MM-dd): ");
                if (DateTime.TryParse(Console.ReadLine(), out DateTime maturityDate))
                {
                    customer.AddAccount(new FixedDepositAccount(accountNumber, maturityDate));
                }
                else
                {
                    Console.WriteLine("Invalid maturity date. Defaulting to one year from now.");
                    customer.AddAccount(new FixedDepositAccount(accountNumber, DateTime.Now.AddMonths(12)));
                }
                break;

            default:
                Console.WriteLine("Invalid account type.");
                break;
        }
    }

    static void MakeTransaction(Bank bank)
    {
        Console.WriteLine("Select Customer:");

        foreach (var newcustomer in bank.GetCustomers())
        {
            Console.WriteLine($"{newcustomer.Name}");
        }

        Console.Write("Enter Customer Name: ");
        string customerName = Console.ReadLine();

        var customer = bank.GetCustomerByName(customerName);

        if (customer == null)
        {
            Console.WriteLine("Customer not found.");
            return;
        }

        Console.WriteLine("Select Account:");

        foreach (var newaccount in customer.GetAccounts())
        {
            Console.WriteLine($"{newaccount.GetAccountType()} - {newaccount.GetAccountNumber()}");
        }

        Console.Write("Enter Account Number: ");
        string accountNumber = Console.ReadLine();

        var account = customer.GetAccountByNumber(accountNumber);

        if (account == null)
        {
            Console.WriteLine("Account not found.");
            return;
        }

        Console.Write("Enter Transaction Amount: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal amount))
        {
            bank.MakeTransaction(account, amount);
        }
        else
        {
            Console.WriteLine("Invalid transaction amount. Please enter a valid number.");
        }
    }
}