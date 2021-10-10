using System;

namespace AbstractFactory
{
    public abstract class Button
    {
        public abstract void Print();
    }

    public class MacButton : Button
    {
        public override void Print()
        {
            Console.WriteLine("MacButton");
        }
    }
    public class WinButton : Button
    {
        public override void Print()
        {
            Console.WriteLine("WinButton");
        }
    }

    public abstract class Checkbox
    {
        public abstract void Print();
    }

    public class MacCheckbox : Checkbox
    {
        public override void Print()
        {
            Console.WriteLine("MacCheckbox");
        }
    }
    public class WinCheckbox : Checkbox
    {
        public override void Print()
        {
            Console.WriteLine("WinCheckbox");
        }
    }



    public interface IGUIFactory
    {
        Button CreatButton();
        Checkbox createCheckbox();
    }

    public class WinFactory : IGUIFactory
    {
        public Button CreatButton() => new WinButton();
        public Checkbox createCheckbox() => new WinCheckbox();
    }

    public class MacFactory : IGUIFactory
    {
        public Button CreatButton() => new MacButton();
        public Checkbox createCheckbox() => new MacCheckbox();
    }


    public class Application
    {
        public Application(IGUIFactory factory) {
            Factory = factory;
        }

        public void CreateUI() {
            Button = Factory.CreatButton();
        }

        public void Paint() {
            Button.Print();
        }

        public IGUIFactory Factory { get; set; }
        public Button Button { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IGUIFactory factory = new WinFactory();
            Application application = new Application(factory);
            application.CreateUI();
            application.Paint();
        }
    }
}
