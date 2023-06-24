using Domain;
using Domainservices.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BoardgameRepository : IBoardgameRepository
    {
        public Task<Boardgame> AddBoardgameAsync(Boardgame boardgame)
        {
            throw new NotImplementedException();
        }

        public Task<Boardgame> GetBoardgameAsync(int boardgameId)
        {
            throw new NotImplementedException();
        }

        public Task<List<Boardgame>> GetBoardgamesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
