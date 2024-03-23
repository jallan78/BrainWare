using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public abstract class EntityBase<TPrimaryKey>
    {
        [Key]
        public virtual TPrimaryKey Id { get; set; }
    }
}
