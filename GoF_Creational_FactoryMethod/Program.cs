using System;

namespace Creational_FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            IAccountFactory factory = new AccountFactory();
            IAccount account = factory.Create();
            account.DepositMoney(100.50m);
            account.DepositMoney(100.50m);
        }

    }

    interface IAccountFactory
    {
        IAccount Create();
    }

    interface IAccount
    {
        decimal Amount { get; }
        void DepositMoney(decimal amount);
    }

    class AccountFactory : IAccountFactory
    {
        public IAccount Create()
        {
            return new Account();
        }
    }

    class Account : IAccount
    {
        public Account()
        {
            Console.WriteLine("Account created.");
            Console.WriteLine($"Current amount is {Amount:c}");
        }

        public decimal Amount { get; private set; }

        public void DepositMoney(decimal amount)
        {
            Amount += amount;
            Console.WriteLine($"Added {amount:c}");
            Console.WriteLine($"Current amount is {Amount:c}");
        }
    }
}
