using System.Threading.Tasks;
using KinoKritic.DAL;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KinoKritic.WEB.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class GenresController : Controller
    {
        private readonly DataContext _context;

        public GenresController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var genres = await _context.Genres.ToListAsync();

            return Ok(genres);
        }
    }
}