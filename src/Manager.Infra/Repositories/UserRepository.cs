using Manager.Domain.Entities;
using Manager.Infra.Context;
using Manager.Infra.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Manager.Infra.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        private readonly ManagerContext _context;
        public UserRepository(ManagerContext context) : base(context)
        {
            _context = context;
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            var obj = await _context.Users
                .Where(u => u.Email.ToLower() == email.ToLower())
                .AsNoTracking()
                .ToListAsync();

            return obj.FirstOrDefault();
        }

        public async Task<List<User>> SearchByEmailAsync(string email)
        {
            var all = await _context.Users
                  .Where(u => u.Email.ToLower().Contains(email.ToLower()))
                  .AsNoTracking()
                  .ToListAsync();

            return all;
        }

        public async Task<List<User>> SearchByNameAsync(string name)
        {
            var all = await _context.Users
                 .Where(u => u.Name.ToLower().Contains(name.ToLower()))
                 .AsNoTracking()
                 .ToListAsync();

            return all;
        }
    }
}
