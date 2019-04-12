using System.Collections.Generic;

namespace FakeAndReal
{
    public class RealManufacturerRepository : IManufacturerRepository
    {
        private AppContext db = new AppContext();

        public IEnumerable<Manufacturer> GetAll()
        {
            using (var context = new AppContext())
            {
                var manufacturers = context.Manufacturers;

                return db.Manufacturers;
            }
        }
    }
}
