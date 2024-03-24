namespace Contract
{
    public class OrderDto
    {
        public int OrderId { get; set; }
        public string CompanyName { get; set; }
        public string Description { get; set; }
        public List<OrderProductDto> OrderProducts { get; set; }
    }
}
