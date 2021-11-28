using System.Threading.Tasks;
using KinoKritic.BLL.Dtos;
using KinoKritic.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KinoKritic.WEB.Controllers
{
    [Route("[controller]")]
    public class CommentsController : Controller
    {
        private readonly ICommentService _commentService;

        public CommentsController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpPost("add")]
        public async Task<IActionResult> CreateComment(CommentCreateDto createCommentDto)
        {
            await _commentService.CreateComment(createCommentDto);
            return RedirectToAction("Details", "Media", new {id = createCommentDto.MediaId});
        }
    }
}