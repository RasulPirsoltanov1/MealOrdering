using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealOrdering.Shared.DTOs
{
    public class UserDTO
    {
        public Guid Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public bool? IsActive { get; set; }
        public string? FullName => $"{FirstName} {LastName}.";

    }
    public class SupplierDTO
    {
        public Guid Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public string? Name { get; set; }
        public string? WebUrl { get; set; }
        public bool? IsActive { get; set; }
    }
    public class OrderDTO
    {
        public Guid Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid? CreateUserId { get; set; }
        public Guid? SupplierId { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public DateTime? ExpireDate { get; set; }
        public string? CreatedUserFullName { get; set; }
        public string? SupplierName { get; set; }
    }
    public class OrderItemDTO
    {
        public Guid Id { get; set; }
        public DateTime? CreateDate { get; set; }
        public Guid? CreateUserId { get; set; }
        public string? Description { get; set; }
        public virtual Guid OrderId { get; set; }
        public string? OrderName { get; set; }
        public string? CreatedUserFullName { get; set; }
    }
}
