using Gs_Contability.Data;
using Gs_Contability.Entities;
using Gs_Contability.Repositories.Common.Filter;
using Gs_Contability.Repositories.Common.Pagination;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Gs_Contability.Repositories.Users
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;

        public UserRepository(Context context)
        {
            _context = context;
        }

        public async Task<User> CreateAsync(User model)
        {
            _context.Users.Add(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public void DeleteById(int key)
        {
            var aluno = _context.Users.Find(key);
            if (aluno != null)
            {
                _context.Users.Remove(aluno);
                _context.SaveChanges();
            }
        }

        public bool ExistsById(int key)
        {
            return _context.Users.Any(e => e.Id == key);
        }

        public PagedResult<User> FindAllPaged(int page, int size)
        {
            var totalElements = _context.Users.Count();
            var items = _context.Users
                .Skip((page - 1) * size)
                .Take(size)
                .ToList();

            return new PagedResult<User>(items, page, size, totalElements);
        }

        public User? FindById(int key)
        {
            return _context.Users.AsNoTracking().FirstOrDefault(a => a.Id == key);
        }

        public User Update(User model)
        {
            _context.Users.Update(model);
            _context.SaveChanges();
            return model;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users
                .AnyAsync(u => u.Email == email);
        }
    }
}
