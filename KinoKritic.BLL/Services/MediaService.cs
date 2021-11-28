using System;
using System.Collections;
using System.Collections.Generic;
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
    public class MediaService : IMediaService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public MediaService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<MediaDto>> GetAllAsync()
        {
            var medias = await _context.Media
                .Include(media => media.Reviews)
                .ThenInclude(review => review.Comments)
                .Include(media => media.Genres)
                .Include(media => media.Type)
                .Include(media => media.Photos).ToListAsync();

            var mediaDtos = _mapper.Map<IEnumerable<MediaDto>>(medias);
            return mediaDtos;
        }

        public async Task<MediaDto> GetByIdAsync(Guid id)
        {
            var media = await _context.Media
                .Include(media => media.Reviews)
                .ThenInclude(review => review.Comments)
                .ThenInclude(user => user.User.Photos)
                .Include(media => media.Reviews)
                .ThenInclude(review => review.Rates)
                .Include(media => media.Genres)
                .Include(media => media.Type)
                .Include(media => media.Photos)
                .FirstOrDefaultAsync(media => media.MediaId == id);
            var mediaDto = _mapper.Map<MediaDto>(media);
            return mediaDto;
        }

        public async Task CreateAsync(MediaDto mediaForCreation)
        {
            var media = _mapper.Map<Media>(mediaForCreation);
            media.Type = _context.MediaType.First();
            media.Photos.Add(new MediaPhoto()
            {
                IsMain = true,
                Url = mediaForCreation.PhotoUrl
            });
            _context.Media.Add(media);
            await _context.SaveChangesAsync();
        }
    }
}