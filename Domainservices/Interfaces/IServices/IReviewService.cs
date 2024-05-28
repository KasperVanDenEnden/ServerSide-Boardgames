using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainservices.Interfaces.IServices
{
    public interface IReviewService
    {
        public Review CreateFromModel(dynamic model, int userId, int gamenightId, string username);
        public Dictionary<string, object> CalculateTotalAndAverageScoreForHost(List<Review> reviews);

    }
}
