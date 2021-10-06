using System;

namespace Creational_AbstrFactory
{
    public enum OSAppearance
    {
        Linux,
        Win
    }

    interface IButton
    {
        void Paint();
    }

    interface IGUIFactory
    {
        IButton CreateButton();
    }

    class WinFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new WinButton();
        }
    }

    class LinuxFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new LinuxButton();
        }
    }

    class WinButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Render Windows style button");
        }
    }

    class LinuxButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Render Linux style button");
        }
    }

    class Program
    {
        static void Main()
        {
            // take this from config file or DB
            var appearance = OSAppearance.Linux;

            IGUIFactory factory;

            switch (appearance)
            {
                case OSAppearance.Win:
                    factory = new WinFactory();
                    break;
                case OSAppearance.Linux:
                    factory = new LinuxFactory();
                    break;
                default:
                    throw new NotImplementedException();
            }

            var button = factory.CreateButton();
            button.Paint();
        }
    }
}
