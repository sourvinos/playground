using System.Collections.Generic;

namespace FakeAndReal
{
    public interface IManufacturerRepository
    {
        IEnumerable<Manufacturer> GetAll();
    }
}
