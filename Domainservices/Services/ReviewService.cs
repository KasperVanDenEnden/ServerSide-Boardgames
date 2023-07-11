using Domain;
using Domainservices.Interfaces.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainservices.Services
{
    public class ReviewService : IReviewService
    {
       

        public Review CreateFromModel(dynamic model, int userId, int gamenightId, string username)
        {
            Review newReview = new Review
            {
                Comment = model.Comment,
                Rating = model.Rating,
                Username = username,
                Posted = DateTime.Now,
                UserId = userId,
                GamenightId = gamenightId
            };
            return newReview;
        }

        public Dictionary<string, object> CalculateTotalAndAverageScoreForHost(List<Review> reviews)
        {
            int total = reviews.Count;
            double totalRating = 0;
            foreach (Review review in reviews)
            {
                totalRating += review.Rating;
            }
            double averageRating = totalRating / reviews.Count;

            Dictionary<string, object> result = new Dictionary<string, object>();
            result["total"] = total;
            result["averageRating"] = averageRating;

            return result;
        }

    }
}
