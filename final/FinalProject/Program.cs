using System;
using System.Collections.Generic;
class Program
{
    static void Main()
    {
        SavingsAccount savingsAccount = new SavingsAccount("SA001", 0.05m);
        CheckingAccount checkingAccount = new CheckingAccount("CA001", 100);
        FixedDepositAccount fixedDepositAccount = new FixedDepositAccount("FDA001", DateTime.Now.AddMonths(12));

        Customer customer = new Customer("Thiago Gouveia");
        customer.AddAccount(savingsAccount);
        customer.AddAccount(checkingAccount);
        customer.AddAccount(fixedDepositAccount);

        savingsAccount.Deposit(1000);
        checkingAccount.Deposit(500);

        Transaction transaction = new Transaction();
        transaction.ProcessTransaction(savingsAccount, 200);
        transaction.ProcessTransaction(checkingAccount, 300);

        fixedDepositAccount.Deposit(2000);

        BankTransactionProcessor transactionProcessor = new BankTransactionProcessor();
        List<Transaction> transactions = new List<Transaction> { transaction, transaction };
        transactionProcessor.ProcessTransactions(transactions);
    }
}