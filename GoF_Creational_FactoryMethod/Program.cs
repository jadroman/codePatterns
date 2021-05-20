using System;

namespace Creational_FactoryMethod
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccountFactory localBankAccFact = new LocalBankAccountFactory();
            BankAccountFactory foreignBankAccFact = new ForeignBankAccountFactory();

            IBankAccount localBankAcc = localBankAccFact.CreateBankAccount();
            localBankAcc.DepositMoney(40);

            IBankAccount foreignBankAcc = foreignBankAccFact.CreateBankAccount();
            foreignBankAcc.DepositMoney(40);

            Console.ReadKey();
        }
    }

    interface IBankAccount
    {
        void DepositMoney(decimal ammount);
    }

    class LocalBankAccount : IBankAccount
    {
        public LocalBankAccount()
        {
            Console.WriteLine("Local bank account created.");
        }

        public void DepositMoney(decimal ammount)
        {
            Console.WriteLine($"Deposit {ammount} of domestic currency.");
        }
    }

    class ForeignBankAccount : IBankAccount
    {
        public ForeignBankAccount()
        {
            Console.WriteLine("Foreign bank account created.");
        }

        public void DepositMoney(decimal ammount)
        {
            Console.WriteLine($"Deposit {ammount} of foreign currency.");
        }
    }

    abstract class BankAccountFactory
    {
        public abstract IBankAccount CreateBankAccount();
    }

    class LocalBankAccountFactory : BankAccountFactory
    {
        public override IBankAccount CreateBankAccount()
        {
            return new LocalBankAccount();
        }
    }

    class ForeignBankAccountFactory : BankAccountFactory
    {
        public override IBankAccount CreateBankAccount()
        {
            return new ForeignBankAccount();
        }
    }
}
