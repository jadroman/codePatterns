using System;

namespace Creational_FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            IBankAccountFactory bankAccFact = new BankAccountFactory();

            IBankAccount bankAccount = bankAccFact.CreateBankAccount();
            bankAccount.DepositMoney(40);

            Console.ReadKey();
        }
    }

    interface IBankAccount
    {
        void DepositMoney(decimal ammount);
    }

    class BankAccount : IBankAccount
    {
        public BankAccount()
        {
            Console.WriteLine("Bank account created.");
        }

        public void DepositMoney(decimal ammount)
        {
            Console.WriteLine($"Deposit {ammount:C}");
        }
    }

    interface IBankAccountFactory
    {
        IBankAccount CreateBankAccount();
    }

    class BankAccountFactory : IBankAccountFactory
    {
        public IBankAccount CreateBankAccount()
        {
            return new BankAccount();
        }
    }

}
