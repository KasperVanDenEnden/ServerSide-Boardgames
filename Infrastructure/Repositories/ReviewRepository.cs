using Domain;
using Domainservices.Interfaces.IRepositories;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;
        public ReviewRepository(ApplicationDbContext applicationDbContext)
        {
            _context = applicationDbContext;
        }

        public async Task<Review> AddReview(Review newReview)
        {
            var review = await _context.Reviews.AddAsync(newReview);
            await _context.SaveChangesAsync();
            if (review != null)
            {
                return review.Entity;
            }
            return null;
        }

        public async Task<List<Review>> GetAllReviewsFromGamenight(int gamenightId)
        {
            var reviews = await _context.Reviews
                            .Where(r => r.Id == gamenightId)
                            .OrderBy(r => r.Posted)
                            .ToListAsync();

            return reviews;
        }

        public async Task<List<Review>> GetAllReviewsForHost(List<int> gamenightIds)
        {
            var reviews = await _context.Reviews
                            .Where(r => gamenightIds.Contains(r.GamenightId))
                            .OrderBy(r => r.Posted)
                            .ToListAsync();

            return reviews;
        }
    }
}

