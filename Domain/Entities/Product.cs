namespace Domain.Entities
{
    public class Product : EntityBase<int>
    {
        public string? Name { get; set; }

        public decimal Price { get; set; }
    }
}
