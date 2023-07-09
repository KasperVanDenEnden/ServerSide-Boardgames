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
    public class ParticipatingRepository : IParticipatingRepository
    {

        private readonly ApplicationDbContext _context;

        public ParticipatingRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Participate(Participating participating)
        {

            await _context.Participating.AddAsync(participating);

            return true;
        }

        public async Task<bool> UnParticipate(int gamenightId, int userId)
        {
            var participating = await _context.Participating.FindAsync(gamenightId, userId);

            if (participating != null) {
                _context.Participating.Remove(participating);
                await _context.SaveChangesAsync();

                return true;
            
            }
            return false;
        }
    }
}
