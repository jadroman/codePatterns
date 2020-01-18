using System;

namespace FluentInterface
{
    class Program
    {
        public class Customer
        {
            public string FullName { get; set; }
            public DateTime Dob { get; set; }
            public string Address { get; set; }

        }

        public class CustomerFluent
        {
            public string Adress { get { return obj.Address; } }

            private Customer obj = new Customer();
            public CustomerFluent NameOfCustomer(string Name)
            {
                obj.FullName = Name;
                return this;
            }
            public CustomerFluent Bornon(string Dob)
            {
                obj.Dob = Convert.ToDateTime(Dob);
                return this;
            }

            public void StaysAt(string Address) => obj.Address = Address;
        }

        static void Main(string[] args)
        {
            CustomerFluent customer = new CustomerFluent();

            customer.NameOfCustomer("Shiv")
                   .Bornon("12/3/1075")
                   .StaysAt("Mumbai");

            Console.WriteLine(customer.Adress);
        }
    }
}
