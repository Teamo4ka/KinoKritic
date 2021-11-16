using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinoKritic.DAL;
using KinoKritic.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KinoKritic.WEB.Controllers
{
    [AllowAnonymous]
    [ApiController]
    [Route("[controller]")]
    public class MediaController : ControllerBase
    {
        private readonly DataContext _context;

        public MediaController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var medias = await _context.Media.ToListAsync();

            return Ok(medias);
        }
        
    }
}