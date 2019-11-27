using System;
using System.Collections.Generic;
using System.Linq;

namespace SOLID_OCP
{
    /// <summary>
    // first we have single class 'Invoice' which calculates Invoice discount depending on account type. 
    // The problem is that every time we adding new account type we will need to change this method.
    // So instead of changing the method every time we are adding new account type we will add new account type class.
    // it also can be done with interface instead base class
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            Invoice FInvoice = new FinalInvoice();
            Invoice PInvoice = new ProposedInvoice();
            Invoice RInvoice = new RecurringInvoice();
            Console.WriteLine(FInvoice.GetInvoiceDiscount(10000));
            Console.WriteLine(PInvoice.GetInvoiceDiscount(10000));
            Console.WriteLine(RInvoice.GetInvoiceDiscount(10000));
        }

        public class Invoice
        {
            public virtual double GetInvoiceDiscount(double amount)
            {
                double finalAmount = 500;
                return finalAmount;
            }
        }


        public class FinalInvoice : Invoice
        {
            public override double GetInvoiceDiscount(double amount)
            {
                return base.GetInvoiceDiscount(amount) - 50;
            }
        }

        public class ProposedInvoice : Invoice
        {
            public override double GetInvoiceDiscount(double amount)
            {
                return base.GetInvoiceDiscount(amount) - 40;
            }
        }

        public class RecurringInvoice : Invoice
        {
            public override double GetInvoiceDiscount(double amount)
            {
                return base.GetInvoiceDiscount(amount) - 30;
            }
        }
    }
}
