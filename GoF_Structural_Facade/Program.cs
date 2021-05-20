using System;

/// <summary>
/// Structural Facade code pattern:
/// A single class that represents an entire subsystem
/// Provide a unified interface to a set of interfaces in a subsystem
/// A Facade shields the user from the complex details of the system and provides them with a simplified 
/// view of it which is easy to use. It also decouples the code that uses the system from the details 
/// of the subsystems, making it easier to modify the system later.
/// </summary>
namespace Structural_Facade
{
    /// <summary>
    /// The 'Subsystem ClassA' class
    /// </summary>
    class Bank
    {
        public bool HasSufficientSavings(Customer c, int amount)
        {
            Console.WriteLine("Check bank for " + c.Name);
            return true;
        }
    }

    
    /// <summary>
    /// The 'Subsystem ClassB' class
    /// </summary>
    class Credit
    {
        public bool HasGoodCredit(Customer c)
        {
            Console.WriteLine("Check credit for " + c.Name);
            return true;
        }
    }
    

    /// <summary>
    /// The 'Subsystem ClassC' class
    /// </summary>
    class Loan
    {
        public bool HasNoBadLoans(Customer c)
        {
            Console.WriteLine("Check loans for " + c.Name);
            return true;
        }
    }
    

    /// <summary>
    /// Customer class
    /// </summary>
    class Customer
    {
        // Constructor
        public Customer(string name)
        {
            Name = name;
        }
        
        // Gets the name
        public string Name { get; }

    }
    
    /// <summary>
    /// The 'Facade' class
    /// </summary>
    class Mortgage
    {
        private Bank _bank = new Bank();
        private Loan _loan = new Loan();
        private Credit _credit = new Credit();
        
        public bool IsEligible(Customer cust, int amount)

        {
            Console.WriteLine("{0} applies for {1:C} loan\n", cust.Name, amount);
            bool eligible = true;

            // Check creditworthyness of applicant
            if (!_bank.HasSufficientSavings(cust, amount))
            {
                eligible = false;
            }
            else if (!_loan.HasNoBadLoans(cust))
            {
                eligible = false;
            }
            else if (!_credit.HasGoodCredit(cust))
            {
                eligible = false;
            }

            return eligible;
        }

        class Program
        {
            static void Main(string[] args)
            {      
                // Facade
                Mortgage mortgage = new Mortgage();
                
                // Evaluate mortgage eligibility for customer
                Customer customer = new Customer("Ann McKinsey");
                bool eligible = mortgage.IsEligible(customer, 125000);
                
                Console.WriteLine("\n" + customer.Name +
                    " has been " + (eligible ? "Approved" : "Rejected"));

                // Wait for user
                Console.ReadKey();
            }
        }
    }
}
