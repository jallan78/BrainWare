using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Company
    {
        [Key]
        public int Company_id { get; set; }
        public required string Name { get; set; }
    }
}
