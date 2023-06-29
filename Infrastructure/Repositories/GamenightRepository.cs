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
            var gamenightEntry = await _context.AddAsync(newGamenight);
            await _context.SaveChangesAsync();

            if (gamenightEntry.Entity != null)
            {
                return gamenightEntry.Entity;
            }

            return null;
        }

        public async Task AddGamenightBoardgameAsync(int gamenightId, List<int> boardgameIds)
        {
            foreach (int boardgameId in boardgameIds)
            {
                var gamenightBoardgame = new GamenightBoardgame
                {
                    GamenightId = gamenightId,
                    BoardgameId = boardgameId
                };

                await _context.GamenightBoardgames.AddAsync(gamenightBoardgame);
            }

            await _context.SaveChangesAsync();
        }

        public async Task<List<Gamenight>> GetGamenightsAsync()
        {
            var gamenights = _context.Gamenights
                .OrderBy(u => u.DateTime)
                .ToList();

            if (gamenights.Any()) { return gamenights; }
            return null;
            throw new NotImplementedException();
        }

        public async Task<List<Gamenight>> GetGamenightsHostingAsync(string username)
        {
            var hosted = await _context.Gamenights
                .Where(u => u.Host.UserName == username)
                .OrderBy(u => u.DateTime)
                .ToListAsync();

            return hosted;
        }

        public async Task<List<Gamenight>> GetGamenightsParticipatingAsync(int userId)
        {
            var participatingList = await _context.Participating.Where(u => u.UserId == userId).ToListAsync();

            if (participatingList != null && participatingList.Count > 0)
            {
                var gamenightIds = participatingList.Select(p => p.GamenightId).ToList();

                var participatingGamenights = await _context.Gamenights
                    .Where(g => gamenightIds.Contains(g.Id))
                    .ToListAsync();

                return participatingGamenights;
            }

            return new List<Gamenight>();
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
