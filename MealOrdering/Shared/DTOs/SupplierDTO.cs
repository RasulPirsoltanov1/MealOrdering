namespace MealOrdering.Shared.DTOs
{
    public class SupplierDTO: BaseDTO
    {
        public DateTime? CreateDate { get; set; }
        public string? Name { get; set; }
        public string? WebUrl { get; set; }
        public bool IsActive { get; set; }
    }
}
