namespace MealOrdering.Shared.DTOs
{
    public class OrderItemDTO: BaseDTO
    {
        public DateTime? CreateDate { get; set; }
        public Guid? CreateUserId { get; set; }
        public string? Description { get; set; }
        public virtual Guid OrderId { get; set; }
        public string? OrderName { get; set; }
        public string? CreatedUserFullName { get; set; }
    }
}
