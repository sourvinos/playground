using System;

namespace Ducks
{
    class PolymorphismThroughInheritance
    {
        // Base class
        public abstract class Duck
        {
            public abstract string Display();

            public string Swim()
            {
                return "I'm swimming.";
            }
        }

        public interface IFlyable
        {
            string Fly();
        }

        public interface IQuackable
        {
            string Quack();
        }

        // Child class
        public class ReadHeadDuck : Duck, IFlyable, IQuackable
        {
            public override string Display()
            {
                return "I'm a ReadHead duck.";
            }

            public string Fly()
            {
                return "I'm flying.";
            }

            public string Quack()
            {
                return "Quack... quack...";
            }
        }

        // Child class
        public class WildDuck : Duck, IFlyable
        {
            public override string Display()
            {
                return "I'm a Wild duck.";
            }

            public string Fly()
            {
                return "I'm flying.";
            }

            public string Quack()
            {
                return "Quack... quack...";
            }
        }

        static void Main02(string[] args)
        {
            // Create an instance of the child class
            ReadHeadDuck myDuck = new ReadHeadDuck();
            Console.WriteLine(myDuck.Display() + " " + myDuck.Quack() + " " + myDuck.Swim() + " " + myDuck.Fly());

            // Create an instance of the child class
            WildDuck myWildDuck = new WildDuck();
            Console.WriteLine(myWildDuck.Display() + " " + myWildDuck.Quack() + " " + myWildDuck.Swim());

            // Wait
            Console.ReadLine();
        }
    }
}