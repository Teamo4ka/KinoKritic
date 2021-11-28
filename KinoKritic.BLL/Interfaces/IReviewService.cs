using System;
using System.Threading.Tasks;
using KinoKritic.BLL.Dtos;

namespace KinoKritic.BLL.Interfaces
{
    public interface IReviewService
    {
        Task CreateReview(ReviewDto reviewForCreation);
        Task LikeReviewToggle(Guid reviewId, string userId);
        Task<ReviewDto> GetByIdAsync(Guid reviewId);
    }
}