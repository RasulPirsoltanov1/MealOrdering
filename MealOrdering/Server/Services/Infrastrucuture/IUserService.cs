using MealOrdering.Shared.DTOs;

namespace MealOrdering.Server.Services.Infrastrucuture
{
    public interface IUserService
    {
        public Task<UserDTO> GetById(Guid Id);
        public Task<List<UserDTO>> GetAll();
        public Task<UserDTO> Create(UserDTO userDTO);
        public Task<UserDTO> Update(UserDTO userDTO);
        public Task<UserDTO> Delete(Guid Id);

    }
}
