using Domain;
using Domain.Many_To_Many;
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
    public class GamenightRepository : IGamenightRepository
    {

        private readonly ApplicationDbContext _context;

        public GamenightRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Gamenight> AddGamenightAsync(Gamenight newGamenight)
        {
            await _context.AddAsync(newGamenight);
            _context.SaveChanges();

            return null;
            
        }

        public async Task<List<Gamenight>> GetGamenightsAsync()
        {
            var gamenights = _context.Gamenights.ToList();
            if (gamenights.Any()) { return gamenights; }
            return null; 
            throw new NotImplementedException();
        }

        public async Task<List<Gamenight>> GetGamenightsHostingAsync(string username)
        {
            var hosted = await _context.Gamenights.Where(u => u.Host.UserName == username).ToListAsync();
            return hosted;
        }

        public async Task<List<Participating>> GetGamenightsParticipatingAsync(string username)
        {
            var user = await _context.User.Include(u => u.ParticipatingGamenights).FirstOrDefaultAsync(u => u.UserName == username);
            if (user != null)
            {
                return user.ParticipatingGamenights;
            }
            return null;
        }

        public Task<bool> RemoveGamenightAsync(int gamenightId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateGamenightAsync(Gamenight gamenight)
        {
            throw new NotImplementedException();
        }
    }
}
