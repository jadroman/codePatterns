using System;

namespace Creational_AbstrFactory
{
    public enum OSAppearance
    {
        OSX,
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

    class OSXFactory : IGUIFactory
    {
        public IButton CreateButton()
        {
            return new OSXButton();
        }
    }

    class WinButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Render Windows style button");
        }
    }

    class OSXButton : IButton
    {
        public void Paint()
        {
            Console.WriteLine("Render OSX style button");
        }
    }

    class Program
    {
        static void Main()
        {
            // take this from config file or DB
            var appearance = OSAppearance.OSX;

            IGUIFactory factory;

            switch (appearance)
            {
                case OSAppearance.Win:
                    factory = new WinFactory();
                    break;
                case OSAppearance.OSX:
                    factory = new OSXFactory();
                    break;
                default:
                    throw new System.NotImplementedException();
            }

            var button = factory.CreateButton();
            button.Paint();
        }
    }
}
