using MealOrdering.Shared.DTOs;

namespace MealOrdering.Server.Services.Infrastrucuture
{
    public interface IGenericService<T> where T : class
    {
        public Task<T> GetById(Guid Id);
        public Task<List<T>> GetAll();
        public Task<T> Create(T entity);
        public Task<T> Update(T entity);
        public Task<T> Delete(Guid Id);
    }
}
