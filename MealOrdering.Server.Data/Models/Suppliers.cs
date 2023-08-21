namespace MealOrdering.Server.Data.Models
{
    public class Suppliers : BaseEntity
    {

        public DateTime? CreateDate { get; set; }
        public string? Name { get; set; }
        public string? WebUrl{ get; set; }
        public bool? IsActive { get; set;  }
        public virtual ICollection<Orders> Orders { get; set; }

    }
}
