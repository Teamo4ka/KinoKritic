using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using KinoKritic.BLL.Interfaces;
using KinoKritic.DAL;
using KinoKritic.DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Profile = KinoKritic.BLL.Dtos.Profile;

namespace KinoKritic.BLL.Services
{
    public class ProfileService : IProfileService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public ProfileService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<Profile> GetProfile(string userId)
        {
            var user = await _context.Users
                .Include(user => user.Photos)
                .FirstOrDefaultAsync(user => user.Id == userId);

            var profile = _mapper.Map<Profile>(user);

            return profile;
        }

        public async Task SetPhoto(string userId, string url)
        {
            var user = await _context.Users
                .Include(user => user.Photos)
                .FirstOrDefaultAsync(user => user.Id == userId);

           var photo = user.Photos.FirstOrDefault(photo => photo.IsMain);
           if (photo == null)
           {
               user.Photos.Add(new UserPhoto()
               {
                   IsMain = true,
                   Url = url
               });
           }
           else
           {
               photo.Url = url;
           }

           await _context.SaveChangesAsync();
        }
    }
}