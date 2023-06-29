using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainservices.Interfaces.IRepositories
{
    public interface IBoardgameRepository
    {
        public Task<bool> AddBoardgameAsync(Boardgame newBoardgame);
        public Task<List<Boardgame>> GetBoardgamesAsync();
        public Task<Boardgame> GetBoardgameByIdAsync(int boardgameId);
    }
}
