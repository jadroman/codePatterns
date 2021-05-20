using System;

namespace Creational_Prototype
{
    class Program
    {
        public abstract class Prototype
        {
            // normal implementation

            public abstract Prototype Clone();
        }

        public class ConcretePrototype1 : Prototype
        {
            public override Prototype Clone()
            {
                return (Prototype)this.MemberwiseClone(); // Clones the concrete class.
            }

            public string SomeMethod => "ConcretePrototype1 method";
            
        }

        public class ConcretePrototype2 : Prototype
        {
            public override Prototype Clone()
            {
                return (Prototype)this.MemberwiseClone(); // Clones the concrete class.
            }


            public string SomeMethod => "ConcretePrototype2 method";
        }

        static void Main(string[] args)
        {
            ConcretePrototype1 cp1 = new ConcretePrototype1();
            ConcretePrototype1 c1_1 = (ConcretePrototype1)cp1.Clone();

            Console.WriteLine(c1_1.SomeMethod);
        }
    }
}
