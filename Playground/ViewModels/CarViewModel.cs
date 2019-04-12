using Playground.Models;
using System.Collections.Generic;

namespace Playground.ViewModels
{
    public class CarViewModel
    {
        public int CarId { get; set; }

        public string ManufacturerDescription { get; set; }
        public string ModelDescription { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public int Km { get; set; }
        public int EngineDisplacement { get; set; }
        public string Power { get; set; }
        public string FuelDescription { get; set; }
        public string GearBoxDescription { get; set; }
        public string Gears { get; set; }
        public string Doors { get; set; }
        public string ColorDescription { get; set; }
        public string Extras { get; set; }
        public decimal Price { get; set; }

        public int ManufacturerId { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }

        public List<Image> Images { get; set; }
    }

}
