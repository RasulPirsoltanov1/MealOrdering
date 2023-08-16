using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealOrdering.Server.Data.Models
{
    public class Users
    {
        public Guid Id { get; set; }
        public DateTime? CreateDate{ get; set; }
        public string? FirstName{ get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool? IsActive{ get; set; }
        public virtual ICollection<Orders> Orders { get; set; }
        public virtual ICollection<OrderItems> OrderItems { get; set; }

    }
}
