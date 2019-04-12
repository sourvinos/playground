using System;

namespace Ducks
{
    public class PolymorphismThroughInterfaces
    {
        // Abstract class Duck
        public abstract class Duck
        {
            public IFlyBehavior flyBehavior;
            public IQuackBehavior quackBehavior;

            public abstract string Display();

            public void SetFlyBehavior(IFlyBehavior fb)
            {
                flyBehavior = fb;
            }

            public void SetQuackBehavior(IQuackBehavior qb)
            {
                quackBehavior = qb;
            }
        }

        // Abstract class DuckMachine
        public abstract class DuckMachine
        {
            public IQuackBehavior quackBehavior;

            public void SetQuackBehavior(IQuackBehavior qb)
            {
                quackBehavior = qb;
            }

            public void PerformQuack()
            {
                quackBehavior.Quack();
            }
        }

        // Concrete Class Duck : Duck
        public class CityDuck : Duck
        {
            public CityDuck()
            {
                flyBehavior = new FlyWithWings();
                quackBehavior = new Quack();
            }

            public override string Display()
            {
                return "I am a city duck";
            }
        }

        // Concrete Class DuckMachine : DuckMachine
        public class FakeDuck : DuckMachine
        {
            public FakeDuck()
            {
                quackBehavior = new Quack();
            }

        }

        // Fly Interface
        public interface IFlyBehavior
        {
            string Fly();
        }

        // Quack Interface
        public interface IQuackBehavior
        {
            string Quack();
        }

        // Concrete FlyBehavior Class : IFlyBehavior
        public class FlyWithWings : IFlyBehavior
        {
            public string Fly()
            {
                return "I am flying with wings!";
            }
        }

        // Concrete FlyBehavior Class : IFlyBehavior
        public class FlyNoWay : IFlyBehavior
        {
            public string Fly()
            {
                return "I do not fly!";
            }
        }

        // Concrete QuackBehavior Class : IQuackBehavior
        public class Quack : IQuackBehavior
        {
            string IQuackBehavior.Quack()
            {
                return "Quacking!";
            }
        }

        // Concrete QuackBehavior Class : IQuackBehavior
        public class Squeak : IQuackBehavior
        {
            public string Quack()
            {
                return "Squeaking!";
            }
        }

        // Concrete FakeQuackBehavior Class : IQuackBehavior
        public class FakeQuack : IQuackBehavior
        {
            public string Quack()
            {
                return "The machine is quacking!";
            }
        }

        // Main
        static void Main03(string[] args)
        {
            // New object
            CityDuck myDuck = new CityDuck();

            // Default behavior according to the constructor
            Console.WriteLine(myDuck.quackBehavior.Quack());
            Console.WriteLine(myDuck.flyBehavior.Fly());

            // Dynamic behavior
            myDuck.SetFlyBehavior(new FlyNoWay());
            Console.WriteLine(myDuck.flyBehavior.Fly());

            // New object (fake duck)
            FakeDuck myFakeDuck = new FakeDuck();

            // Dynamic behavior
            myFakeDuck.SetQuackBehavior(new FakeQuack());
            Console.WriteLine(myFakeDuck.quackBehavior.Quack());
        }
    }
}