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
    public class MediaTypeController : Controller
    {
        private readonly DataContext _context;

        public MediaTypeController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var types = await _context.MediaType.ToListAsync();

            return Ok(types);
        }
    }
}