using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MealOrdering.Shared.DTOs
{
    public class UserDTO:BaseDTO
    {
        public DateTime? CreateDate { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public bool IsActive { get; set; }
        public string? FullName => $"{FirstName} {LastName}.";
    }
}
