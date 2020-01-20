using System;

/// <summary>
/// Creational Singleton pattern:
/// Ensure a class has only one instance and provide a global point of access to it.
///	Prevent multiple instances of the class.
/// Ensuring that all objects access the single instance.
///	Used when we can reuse object instead of creating new ones, eg. Logger Classes, Configuration Classes...
/// </summary>
namespace Creational_Singleton
{

    /// <summary>
    /// MainApp startup class for Structural
    /// Singleton Design Pattern.
    /// </summary>
    class MainApp
    {
        /// <summary>
        /// Entry point into console application.
        /// </summary>
        static void Main()
        {
            // Constructor is protected -- cannot use new
            Singleton s1 = Singleton.Instance();
            Singleton s2 = Singleton.Instance();

            s1.broj = 1;
            s2.broj = 2;

            Console.WriteLine("s1.broj = " + s1.broj);
            Console.WriteLine("s2.broj = " + s2.broj);

            // Wait for user
            Console.ReadKey();
        }

    }

    /// <summary>
    /// The 'Singleton' class
    /// </summary>
    class Singleton
    {
        private static Singleton _instance;
        public int broj;

        // Constructor is 'protected'
        protected Singleton(){}

        public static Singleton Instance()
        {
            // Uses lazy initialization.
            // Note: this is not thread safe.
            if (_instance == null)
            {
                _instance = new Singleton();
            }

            return _instance;
        }

    }
}
