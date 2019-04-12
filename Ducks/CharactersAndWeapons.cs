using System;

namespace Ducks
{
    public class CharactersAndWeapons
    {
        // Base abstract class
        public abstract class Character
        {
            protected IWeaponBehavior wb;

            public void SetWeapon(IWeaponBehavior weaponBehavior)
            {
                wb = weaponBehavior;
            }

            public string Fight()
            {
                return wb.UseWeapon();
            }

            public abstract string DisplayName();
        }

        // Concrete implementation of the Character Class
        public class Queen : Character
        {
            public Queen()
            {
                wb = new NoWeaponBehavior();
            }

            public override string DisplayName()
            {
                return "I am a Queen";
            }
        }

        // Concrete implementation of the Character Class
        public class King : Character
        {
            public override string DisplayName()
            {
                return "I am a King";
            }
        }

        // Concrete implementation of the Character Class
        public class Knight : Character
        {
            public override string DisplayName()
            {
                return "I am a Knight";
            }
        }

        // Weapon Interface
        public interface IWeaponBehavior
        {
            string UseWeapon();
        }

        // Concrete implementation of the Weapon interface
        public class NoWeaponBehavior : IWeaponBehavior
        {
            public string UseWeapon()
            {
                return "without weapon";
            }
        }

        // Concrete implementation of the Weapon interface
        public class KnifeBehavior : IWeaponBehavior
        {
            public string UseWeapon()
            {
                return "cutting with a knife";
            }
        }

        // Concrete implementation of the Weapon interface
        public class BowAndArrowBehavior : IWeaponBehavior
        {
            public string UseWeapon()
            {
                return "throwing an arrow";
            }
        }

        // Concrete implementation of the Weapon interface
        public class AxeBehavior : IWeaponBehavior
        {
            public string UseWeapon()
            {
                return "chopping with an axe";
            }
        }

        // Concrete implementation of the Weapon interface
        public class SwordBehavior : IWeaponBehavior
        {
            public string UseWeapon()
            {
                return "cutting with a sword";
            }
        }

        // Main
        static void Main(string[] args)
        {
            King myKing = new King();
            myKing.SetWeapon(new BowAndArrowBehavior());
            Console.WriteLine(myKing.DisplayName() + " and I am " + myKing.Fight() + ".");

            Queen myQueen = new Queen();
            Console.WriteLine(myQueen.DisplayName() + " and I am " + myQueen.Fight() + ".");
            myQueen.SetWeapon(new AxeBehavior());
            Console.WriteLine(myQueen.DisplayName() + " and I am " + myQueen.Fight() + ".");
        }
    }
}
