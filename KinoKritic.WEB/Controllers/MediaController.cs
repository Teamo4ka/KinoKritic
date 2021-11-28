using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinoKritic.BLL.Dtos;
using KinoKritic.BLL.Interfaces;
using KinoKritic.DAL;
using KinoKritic.DAL.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KinoKritic.WEB.Controllers
{
    [AllowAnonymous]
    [Route("[controller]")]
    public class MediaController : Controller
    {
        private readonly IMediaService _mediaService;

        public MediaController(IMediaService mediaService)
        {
            _mediaService = mediaService;
        }


        [HttpGet("all")]
        public async Task<ViewResult> GetAll()
        {
            var medias = await _mediaService.GetAllAsync();

            return View(medias);
        }

        [HttpGet("{id}")]
        public async Task<ViewResult> Details(Guid id)
        {
            var media = await _mediaService.GetByIdAsync(id);
            return View(media);
        }
        
        [HttpGet("api/all")]
        public async Task<IActionResult> GetAllApi()
        {
            var medias = await _mediaService.GetAllAsync();

            return Ok(medias);
        }

        [HttpGet("api/{id}")]
        public async Task<IActionResult> DetailsApi(Guid id)
        {
            var media = await _mediaService.GetByIdAsync(id);
            return Ok(media);
        }

        [HttpPost("create")]
        public async Task<RedirectToActionResult> Create(MediaDto mediaForCreation)
        {
            await _mediaService.CreateAsync(mediaForCreation);

            return RedirectToAction("GetAll");
        }

        [HttpGet("new")]
        public ViewResult New()
        {
            return View();
        }
    }
}