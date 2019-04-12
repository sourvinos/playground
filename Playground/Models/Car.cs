namespace Playground.Models
{
    public class Car
    {
        public int CarId { get; set; }

        public int ManufacturerId { get; set; }
        public int ModelId { get; set; }
        public int ColorId { get; set; }
        public string Month { get; set; }
        public string Year { get; set; }
        public decimal Price { get; set; }

        public Manufacturer Manufacturer { get; set; }
        public Model Model { get; set; }
        public Color Color { get; set; }
    }
}
