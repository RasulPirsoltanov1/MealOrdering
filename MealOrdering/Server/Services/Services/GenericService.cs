using AutoMapper;
using MealOrdering.Server.Data.Context;
using MealOrdering.Server.Data.Models;
using MealOrdering.Server.Services.Infrastrucuture;
using MealOrdering.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MealOrdering.Server.Services.Services
{
    public class GenericService<T> : IGenericService<T> where T : BaseEntity
    {

        private readonly IMapper _mapper;
        private readonly MealOrderingDbContext _context;
        public GenericService(IMapper mapper, MealOrderingDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<T> Create(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(Guid Id)
        {
            var entity = _context.Users.Find(Id);
            if (entity != null)
            {
                _context.Remove(entity);
                await _context.SaveChangesAsync();
                return _mapper.Map<T>(entity);
            }
            else
            {
                throw new Exception("User cant define!");
            }
        }

        public async Task<List<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetById(Guid Id)
        {
            var user = await _context.Set<T>().FirstOrDefaultAsync(x => x.Id == Id);
            if (user != null)
            {
                return _mapper.Map<T>(user);
            }
            else
            {
                throw new Exception("User cant define!");
            }
        }

        public async Task<T> Update(T entity)
        {
            var entry = _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();

            // Access the updated entity using the Entity property of EntityEntry
            return _mapper.Map<T>(entry.Entity);
        }
    }
}
