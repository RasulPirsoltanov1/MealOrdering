namespace MealOrdering.Server.Data.Models
{
    public class OrderItems:BaseEntity
    {
        public DateTime? CreateDate { get; set; }
        public Guid? CreateUserId { get; set; }
        public string? Description { get; set; }
        public virtual Guid OrderId { get; set; }
        public virtual Orders Order { get; set; }
        public virtual Users User{ get; set; }
    }
}
