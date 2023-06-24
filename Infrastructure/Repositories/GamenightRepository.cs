using Domain;
using Domainservices.Interfaces.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GamenightRepository : IGamenightRepository
    {
        public Task<Gamenight> AddGamenightAsync(Gamenight newGamenight)
        {
            throw new NotImplementedException();
        }

        public Task<List<Gamenight>> GetGamenightsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<List<Gamenight>> GetGamenightsHostingAsync(string username)
        {
            throw new NotImplementedException();
        }

        public Task<List<Gamenight>> GetGamenightsParticipatingAsync(int userId)
        {
            throw new NotImplementedException();
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
