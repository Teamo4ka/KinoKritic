using System;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KinoKritic.BLL.Dtos;
using KinoKritic.BLL.Interfaces;
using KinoKritic.DAL;
using KinoKritic.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace KinoKritic.BLL.Services
{
    public class ReviewService : IReviewService
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public ReviewService(DataContext context, IMapper mapper, IUserAccessor userAccessor)
        {
            _context = context;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task CreateReview(ReviewDto reviewForCreation)
        {
            var review = _mapper.Map<Review>(reviewForCreation);
            review.UserId = _userAccessor.GetUserId();
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
        }

        public async Task LikeReviewToggle(Guid reviewId, string userId)
        {
            var reviewRate =
                await _context.ReviewRates.FirstOrDefaultAsync(review =>
                    review.ReviewId == reviewId && review.UserId == userId);
            if (reviewRate == null)
            {
                var review = await _context.Reviews.FindAsync(reviewId);
                var user = await _context.Users.FindAsync(userId);
                var rate = new ReviewRate()
                {
                    isLiked = true,
                    Review = review,
                    User = user
                };
                _context.ReviewRates.Add(rate);
                await _context.SaveChangesAsync();
                return;
            }

            reviewRate.isLiked = !reviewRate.isLiked;
            await _context.SaveChangesAsync();
        }

        public async Task<ReviewDto> GetByIdAsync(Guid reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            var reviewDto = _mapper.Map<ReviewDto>(review);
            return reviewDto;
        }
    }
}