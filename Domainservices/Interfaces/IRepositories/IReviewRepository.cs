using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainservices.Interfaces.IRepositories
{
    public interface IReviewRepository
    {
        public Task<Review> AddReview(Review newReview);
        public Task<List<Review>> GetAllReviewsFromGamenight(int gamenightId);
        public Task<List<Review>> GetAllReviewsForHost(List<int> gamenightIds);
    }
}
