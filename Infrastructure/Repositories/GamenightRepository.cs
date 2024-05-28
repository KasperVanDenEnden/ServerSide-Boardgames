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

        public async Task<Gamenight> GetGamenightAsync(int gamenightId)
        {
            var gamenight = await _context.Gamenights
                .Include(gn => gn.Participants)
                .ThenInclude(p => p.User)
                .Include(gn => gn.Host)
                .Include(gn => gn.Address)
                .Include(gn => gn.Reviews)
                .Include(gn => gn.Boardgames)
                    .ThenInclude(bg => bg.Boardgame)
                .FirstOrDefaultAsync(gn => gn.Id == gamenightId);

            return gamenight;
        }

        public async Task<List<Gamenight>> GetGamenightsAsync()
        {
            var gamenights = _context.Gamenights
                .OrderBy(u => u.DateTime)
                .ToList();

            if (gamenights.Any()) { return gamenights; }
            return null;
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
            var participatingList = await _context.Participatings.Where(u => u.UserId == userId).ToListAsync();

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

        

        public async Task<bool> RemoveGamenightAsync(int gamenightId)
        {
            var gamenight = await _context.Gamenights.FindAsync(gamenightId);

            if (gamenight == null)
                return false; // Gamenight with specified ID not found

            _context.Gamenights.Remove(gamenight);
            await _context.SaveChangesAsync();

            return true; // Gamenight deleted successfully
        }


        public async Task<bool> UpdateGamenightAsync(Gamenight gamenight)
        {
            var existingGamenight = await _context.Gamenights.FindAsync(gamenight.Id);

            if (existingGamenight == null)
                return false; // Gamenight with specified ID not found

            _context.Entry(existingGamenight).CurrentValues.SetValues(gamenight);
            await _context.SaveChangesAsync();

            return true; // Gamenight updated successfully
        }


        public async Task<List<int>> GetHostGamenightIds(int hostId)
        {
            List<int> gamenightIds = await _context.Gamenights
                .Where(gn => gn.Host.Id == hostId)
                .Select(gn => gn.Id)
                .ToListAsync();

            return gamenightIds;
        }

    }
}
