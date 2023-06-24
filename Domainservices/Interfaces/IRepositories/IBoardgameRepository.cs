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
        public Task<Boardgame> AddBoardgameAsync(Boardgame boardgame);
        public Task<List<Boardgame>> GetBoardgamesAsync();
        public Task<Boardgame> GetBoardgameAsync(int boardgameId);
        
    }
}
