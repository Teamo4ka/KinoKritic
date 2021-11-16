using System;
using System.Security.Claims;
using System.Threading.Tasks;
using KinoKritic.BLL.Interfaces;
using KinoKritic.DAL.Entities;
using KinoKritic.WEB.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KinoKritic.WEB.Controllers
{
   [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly ITokenService _tokenService;
        
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }
        
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Current()
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(x => 
                x.Email == HttpContext.User.FindFirstValue(ClaimTypes.Email));

            if (user == null) return Unauthorized();
            var roles = await _userManager.GetRolesAsync(user);

            var isAdmin = roles.Contains("Admin");
            return Ok(await CreateUserObject(user, isAdmin));
           
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<UserDto>> Login(LoginDto loginDto)
        {
            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Email == loginDto.Email);

            if (user == null) return Unauthorized();

            var result = await _signInManager.CheckPasswordSignInAsync(user, loginDto.Password, false);

            var roles = await _userManager.GetRolesAsync(user);

            var isAdmin = roles.Contains("Admin");
            if (result.Succeeded)
            {
                return await CreateUserObject(user, isAdmin);
            }

            return Unauthorized();
        }

        private async Task<UserDto> CreateUserObject(AppUser user, bool isAdmin)
        {
            return new UserDto
            {
                DisplayName = user.DisplayName,
                Token = await _tokenService.CreateToken(user),
                isAdmin = isAdmin,
                Username = user.UserName,
            };
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register(RegisterDto registerDto)
        {
            var user = await _userManager.FindByEmailAsync(registerDto.Email);

            if (user != null)
            {
                ModelState.AddModelError("email", "Email taken");
                return ValidationProblem(ModelState);
            }

            user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == registerDto.Username);

            if (user != null)
            {
                ModelState.AddModelError("username", "Username taken");
                return ValidationProblem(ModelState);
            }

            user = new AppUser
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.Username,
            };


            var result = await _userManager.CreateAsync(user, registerDto.Password);

            
            if (result.Succeeded)
            {
                return await CreateUserObject(user, false);
            }

            return Unauthorized();
        }
       
        
        
    }
}