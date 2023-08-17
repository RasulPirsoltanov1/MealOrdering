using AutoMapper;
using MealOrdering.Server.Data.Context;
using MealOrdering.Server.Services.Infrastrucuture;
using MealOrdering.Shared.DTOs;
using Microsoft.EntityFrameworkCore;

namespace MealOrdering.Server.Services.Services
{
    public class GenericService<T>:IGenericService<T> where T : BaseDTO
    {

        private readonly IMapper _mapper;
        private readonly MealOrderingDbContext _context;
        public GenericService(IMapper mapper, MealOrderingDbContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<T> Create(T userDTO)
        {
            await _context.AddAsync(userDTO);
            await _context.SaveChangesAsync();
            return userDTO;
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
            return _mapper.Map<List<T>>(await _context.Users.Where(u => u.IsActive == true).ToListAsync());
        }

        public async Task<T> GetById(Guid Id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
            if (user != null)
            {
                return _mapper.Map<T>(user);
            }
            else
            {
                throw new Exception("User cant define!");
            }
        }

        public async Task<T> Update(T userDTO)
        {
            var entity = _context.Users.Find(userDTO.Id);
            if (entity != null)
            {
                _mapper.Map(userDTO, entity);
                await _context.SaveChangesAsync();
                return _mapper.Map<T>(entity);
            }
            else
            {
                throw new Exception("User cant define!");
            }
        }
    }
}
