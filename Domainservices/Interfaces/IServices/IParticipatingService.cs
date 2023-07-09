using Domain;
using Domain.Many_To_Many;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainservices.Interfaces.IServices
{
    public interface IParticipatingService
    {
        bool ParticipateAllowed(Gamenight gamenight, User user);
        bool UnParticipateAllowed(Gamenight gamenight, int userId);
        public bool UserIsCurrentlyParticipating(int userId, List<Participating> participants);
        public bool CheckIfOldEnough(bool IsPG18, DateOnly dateOfBirth);
        public bool CheckIfGamenightIsFull(int max, List<Participating> participants);
    }
}
