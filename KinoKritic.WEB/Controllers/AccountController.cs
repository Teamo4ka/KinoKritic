using System;
using System.Threading.Tasks;
using Azure.Storage;
using Azure.Storage.Blobs;
using KinoKritic.BLL.Interfaces;
using KinoKritic.DAL.Entities;
using KinoKritic.WEB.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace KinoKritic.WEB.Controllers
{
    [Route("[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IProfileService _profileService;
        private readonly IUserAccessor _userAccessor;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IProfileService profileService, IUserAccessor userAccessor)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _profileService = profileService;
            _userAccessor = userAccessor;
        }

        [HttpGet("changePhoto")]
        public async Task<ViewResult> ChangePhoto()
        {
            var profile = await _profileService.GetProfile(_userAccessor.GetUserId());
            return View(profile);
        }
        
        // GET
        [HttpGet("login")]
        public IActionResult LogIn( string returnUrl = null)
        {
            return View(new LogInVM() { ReturnUrl = returnUrl });
        }

        // GET
        [HttpGet("register")]
        public IActionResult Register()
        {
            return View(new RegisterVM { ReturnUrl ="/Home/Index"});
        }

        // POST
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { Email = registerVM.Email, UserName = registerVM.UserName };

                if(string.Compare(registerVM.Password, registerVM.ConfirmPassword) != 0)
                {
                    ModelState.AddModelError("", "Passwords aren't coincided");
                    return View(registerVM);
                }

                var result = await _userManager.CreateAsync(user, registerVM.Password);

                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    RedirectToAction("Index", "Home");
                }
            }
            return View(registerVM);
        }

        // POST
        [HttpPost("login")]
 
        public async Task<IActionResult> LogIn(LogInVM loginVM)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager
                    .PasswordSignInAsync(loginVM.UserName, loginVM.Password,
                    loginVM.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(loginVM.ReturnUrl) && Url.IsLocalUrl(loginVM.ReturnUrl))
                        return Redirect(loginVM.ReturnUrl);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Something wrong with login or password");
            }

            return View(loginVM);

        }

        [HttpPost("change")]
        public async Task<IActionResult> ChangePhoto([FromForm] IFormFile file)
        {
            var userId = _userAccessor.GetUserId();
            Uri blobUri = new Uri("https://" +
                                  "rhzstorage" +
                                  ".blob.core.windows.net/" +
                                  "rhzimagestorage" +
                                  "/" + Guid.NewGuid().ToString() + "." + file.FileName.Split('.')[1]);

            // Create StorageSharedKeyCredentials object by reading
            // the values from the configuration (appsettings.json)
            StorageSharedKeyCredential storageCredentials =
                new StorageSharedKeyCredential("rhzstorage" ,"JCUdy8ItMUdCbh90n69k2sTRfQgcupQ4ZkkfuiUD1LuzQUbQhRoXILZoopkaOT+4h0eQmNeeiU8JykSJP/K/Ww==");

            // Create the blob client.
            BlobClient blobClient = new BlobClient(blobUri, storageCredentials);

            // Upload the file
            await blobClient.UploadAsync(file.OpenReadStream());

           await _profileService.SetPhoto(_userAccessor.GetUserId(), blobUri.ToString());
           return Redirect("/account/changePhoto");

        }


        // POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
