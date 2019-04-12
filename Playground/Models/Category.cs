using System.ComponentModel.DataAnnotations;

namespace Playground.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(200)]
        public string CategoryName { get; set; }
    }
}
