using Domain;
using Domainservices.Interfaces.IRepositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BoardgameRepository : IBoardgameRepository
    {
        private readonly ApplicationDbContext _context;

        public BoardgameRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }
        public async Task<bool> AddBoardgameAsync(Boardgame newBoardgame)
        {
            try
            {
                var boardgame = await _context.Boardgame.AddAsync(newBoardgame);
                await _context.SaveChangesAsync();
                if (boardgame != null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return false;



            throw new NotImplementedException();
        }

        public async Task<Boardgame> GetBoardgameByIdAsync(int boardgameId)
        {
            var boardgame = await _context.Boardgame.FindAsync(boardgameId);

            if (boardgame != null)
            {
                return boardgame;
            }
            return new Boardgame();
        }

        public async Task<List<Boardgame>> GetBoardgamesAsync()
        {
            var boardgames = await _context.Boardgame.ToListAsync();
            if (boardgames != null) return boardgames;
            return new List<Boardgame>();
        }
    }
}
