using System.Collections.Generic;
using System.Linq;

namespace FakeAndReal
{
    public class FakeManufacturerRepository : IManufacturerRepository
    {
        private List<Manufacturer> manufacturers;

        public FakeManufacturerRepository()
        {
            manufacturers = new List<Manufacturer>
            {
                new Manufacturer{ Id = 1, Description = "AUDI"},
                new Manufacturer{ Id = 2, Description = "VW"},
                new Manufacturer{ Id = 3, Description = "MERCEDES"},
                new Manufacturer{ Id = 4, Description = "BMW"}
            };
        }

        public IEnumerable<Manufacturer> GetAll()
        {
            return manufacturers.ToList();
        }
    }
}
