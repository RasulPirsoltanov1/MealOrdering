namespace MealOrdering.Server.Data.Models
{
    public class Orders : BaseEntity
    {

        public DateTime? CreateDate { get; set; }
        public Guid? CreateUserId { get; set; }
        public Guid? SupplierId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? ExpireDate { get; set; }

        public virtual Users User { get; set; }
        public virtual Suppliers Supplier { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }
    }
}
