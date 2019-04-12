using System;

namespace FakeAndReal
{
    class Core
    {
        // Variables
        private IManufacturerRepository manufacturers;

        // Dependency injection 
        public Core(IManufacturerRepository manufacturers)
        {
            this.manufacturers = manufacturers;
        }

        static void Main(string[] args)
        {
            // From memory
            var fakeApp = new Core(new FakeManufacturerRepository());

            Console.WriteLine("From memory");

            foreach (var manufacturer in fakeApp.manufacturers.GetAll())
            {
                Console.WriteLine("{0} {1}", manufacturer.Id, manufacturer.Description);
            }

            // From database
            Console.WriteLine("From database");

            var realApp = new Core(new RealManufacturerRepository());

            foreach (var manufacturer in realApp.manufacturers.GetAll())
            {
                Console.WriteLine("{0} {1}", manufacturer.Id, manufacturer.Description);
            }
        }
    }
}