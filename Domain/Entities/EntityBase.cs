using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    /// <summary>
    /// If I had more time to refactor this code, I would create a base class for all entities that have an Id property.
    /// </summary>
    public abstract class EntityBase<TPrimaryKey>
    {
        [Key]
        public virtual TPrimaryKey Id { get; set; }
    }
}
