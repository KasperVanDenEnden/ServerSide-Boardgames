using Domain.Many_To_Many;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainservices.Interfaces.IRepositories
{
    public interface IParticipatingRepository
    {
        public Task<bool> Participate(Participating participating);
        public Task<bool> UnParticipate(int gamenightId, int userId);
    }
}
