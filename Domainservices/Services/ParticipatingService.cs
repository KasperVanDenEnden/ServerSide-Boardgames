using Domain;
using Domain.Many_To_Many;
using Domainservices.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainservices.Services
{
    public class ParticipatingService : IParticipatingService
    {
        public bool ParticipateAllowed(Gamenight gamenight, User user)
        {

            if (!UserIsCurrentlyParticipating(user.Id,gamenight.Participants))
            {
                DateOnly userDateOfBirth = new (user.DateOfBirth.Year, user.DateOfBirth.Month, user.DateOfBirth.Day);
                var AgeCheck = this.CheckIfOldEnough(gamenight.IsPG18, userDateOfBirth);
                var FullCheck = this.CheckIfGamenightIsFull(gamenight.MaxParticipants, gamenight.Participants);

                if(AgeCheck && FullCheck) { return true; }
            }

            return false;
        }

        public bool UnParticipateAllowed(Gamenight gamenight, int userId)
        {
            if (UserIsCurrentlyParticipating(userId, gamenight.Participants))
            {
                return true;
            }
            return false;
        }

        public bool UserIsCurrentlyParticipating(int userId, List<Participating> participants)
        {
            if (participants.Any(p => p.UserId == userId)) { return false; }
            return true;
        }

        public bool CheckIfOldEnough(bool IsPG18, DateOnly dateOfBirth)
        {
            if (IsPG18)
            {
                var currentDate = DateOnly.FromDateTime(DateTime.Today);
                var age = currentDate.Year - dateOfBirth.Year;

                if (dateOfBirth > currentDate.AddYears(-age))
                {
                    age--;
                }

                return age >= 18;
            }

            return true; // If IsPG18 is false, consider the person old enough
        }

        public bool CheckIfGamenightIsFull(int max, List<Participating> participants)
        {
            return participants.Count >= max;
        }

       

     
    }
}
