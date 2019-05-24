using System;

/// <summary>
/// States "that clients should not be forced to implement interfaces they don't use.
/// Instead of one fat interface many small interfaces are preferred based on groups of methods, each one serving one sub module.
/// </summary>
namespace SOLID_ISP
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        public interface ICar
        {
            void Drive();
        }

        public interface IAirplane
        {
            void Fly();
        }

        public interface IMultiFunctionalVehicle : ICar, IAirplane
        {
        }

        public class Car : ICar
        {
            public void Drive()
            {
                //actions to drive a car
                Console.WriteLine("Driving a car");
            }
        }

        public class Airplane : IAirplane
        {
            public void Fly()
            {
                //actions to fly a plane
                Console.WriteLine("Flying a plane");
            }
        }

        public class MultiFunctionalCar : IMultiFunctionalVehicle
        {
            public void Drive()
            {
                //actions to start driving car
                Console.WriteLine("Drive a multifunctional car");
            }

            public void Fly()
            {
                //actions to start flying
                Console.WriteLine("Fly a multifunctional car");
            }
        }
    }
}
