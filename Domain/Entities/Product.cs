using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Product 
    {
        [Key]
        public int Product_id { get; set; }
        public string? Name { get; set; }
        public decimal Price { get; set; }
    }
}
