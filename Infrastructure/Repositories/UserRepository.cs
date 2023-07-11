using Domain;
using Domainservices.Interfaces.IRepositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;
        public UserRepository(ApplicationDbContext context) {
            _context = context;
        }

        public async Task<bool> AddUserAsync(User newUser)
        {
            var user = await _context.Users.AddAsync(newUser);
            await _context.SaveChangesAsync();

            if (user != null) { return true ; }
            return false;

        }

        public async Task<User> GetUserAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user != null) { return user; }
            return null;
        }

        public async Task<int> GetUserIdAsync(string username)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);

            if (user != null) { return user.Id; }
            return 0;
        }
    }
}
