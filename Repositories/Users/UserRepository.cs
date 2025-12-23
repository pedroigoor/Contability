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

        public async Task DeleteByIdAsync(int key)
        {
            var aluno = await _context.Users.FindAsync(key);
            if (aluno != null)
            {
                _context.Users.Remove(aluno);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistsByIdAsync(int key)
        {
            return await _context.Users.AnyAsync(e => e.Id == key);
        }

        public async Task<PagedResult<User>> FindAllPagedAsync(int page, int size)
        {
            var totalElements = await _context.Users
         .AsNoTracking()
         .CountAsync();

            var items = await _context.Users
                .AsNoTracking()
                .Skip((page - 1) * size)
                .Take(size)
                .ToListAsync();

            return new PagedResult<User>(items, page, size, totalElements);
        }

        public async Task<User?> FindByIdAsync(int key)
        {
            return await _context.Users.AsNoTracking().FirstOrDefaultAsync(a => a.Id == key);
        }

        public async Task<User> UpdateAsync(User model)
        {
            _context.Users.Update(model);
            await _context.SaveChangesAsync();
            return model;
        }

        public async Task<bool> EmailExistsAsync(string email)
        {
            return await _context.Users
                .AnyAsync(u => u.Email == email);
        }
    }
}
