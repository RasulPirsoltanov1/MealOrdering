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
    }
    public class Orders
    {
        public Guid Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid? CreateUserId{ get; set; }
        public Guid? SupplierId{ get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? ExpireDate { get; set; }
    }
}
