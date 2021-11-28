using System;
using System.Security.Claims;
using System.Threading.Tasks;
using KinoKritic.BLL.Dtos;
using KinoKritic.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KinoKritic.WEB.Controllers
{
    [Route("[controller]")]
    public class ReviewsController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> Create(ReviewDto reviewForCreation)
        {
            await _reviewService.CreateReview(reviewForCreation);
            return RedirectToAction("Details", "Media", new {id = reviewForCreation.MediaId});
        }
        [HttpPost("{id}/like")]
        public async Task<IActionResult> Create(Guid id)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            await _reviewService.LikeReviewToggle(id, userId);
            var review = await _reviewService.GetByIdAsync(id);
            return RedirectToAction("Details", "Media", new {id = review.MediaId});
        }
    }
}