using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class OrderProduct
    {
        [Key]
        public int Order_id { get; set; }
        [ForeignKey("Product")]
        public int? Product_id { get; set; }

        public virtual Product Product { get; set; }

        [ForeignKey("Order")]
        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
