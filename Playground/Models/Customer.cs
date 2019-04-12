namespace Playground.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Identity { get; set; }

        public int TaxOfficeId { get; set; }

        public TaxOffice TaxOffice { get; set; }
    }
}
