namespace Domain.Entities
{
    public class Order : EntityBase<int>
    {
        public string CompanyName { get; set; }

        public string Description { get; set; }

        public decimal OrderTotal { get; set; }
        
        public int? OrderProductId { get; set; }

        public virtual List<OrderProduct> OrderProducts { get; set; }
    }
}
