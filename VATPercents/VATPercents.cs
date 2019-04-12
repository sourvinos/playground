using System;

namespace VATPercents
{
    class VATPercents
    {
        // Base abstract class
        public abstract class Product
        {
            protected IVAT vat;

            public string Name;
            public decimal Price;

            public void SetVATPercent(IVAT vatPercent)
            {
                vat = vatPercent;
            }

            public decimal CalculateTotalPrice()
            {
                return Price + Price * vat.SetVATPercent();
            }

            public string DisplayName()
            {
                return Name;
            }
        }

        // Concrete implementation of Product class
        public class Book : Product { }

        // VAT interface
        public interface IVAT
        {
            decimal SetVATPercent();
        }

        // Concrete implementation of VAT interface
        public class VAT14Percent : IVAT
        {
            public decimal SetVATPercent()
            {
                return 0.14m;
            }
        }

        // Concrete implementation of VAT interface
        public class VAT24Percent : IVAT
        {
            public decimal SetVATPercent()
            {
                return 0.24m;
            }
        }

        // Main
        static void Main(string[] args)
        {
            Book myBook = new Book
            {
                Name = "Design Patterns",
                Price = 90
            };

            myBook.SetVATPercent(new VAT24Percent());

            Console.WriteLine(myBook.DisplayName() + " " + myBook.CalculateTotalPrice());
        }
    }
}