using MealOrdering.Server.Data.Models;
using MealOrdering.Shared.DTOs;

namespace MealOrdering.Server.Services.Infrastrucuture
{
    public interface IUserService:IGenericService<UserDTO>
    {
        Task<string> Login(string email,string password);
    }
}
