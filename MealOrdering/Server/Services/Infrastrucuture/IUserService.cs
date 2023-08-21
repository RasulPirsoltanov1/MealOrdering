using MealOrdering.Server.Data.Models;
using MealOrdering.Shared.DTOs;

namespace MealOrdering.Server.Services.Infrastrucuture
{
    public interface IUserService:IGenericService<Users>
    {
        Task<UserLoginResponseDTO> Login(string email,string password);
    }
}
