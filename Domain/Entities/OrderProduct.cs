namespace Domain.Entities
{
    public class OrderProduct : EntityBase<int>
    {
        public int? ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }

        public decimal Price { get; set; }
    }
}
