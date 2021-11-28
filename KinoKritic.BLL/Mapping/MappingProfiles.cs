using System.Linq;
using AutoMapper;
using KinoKritic.BLL.Dtos;
using KinoKritic.DAL.Entities;

namespace KinoKritic.BLL.Mapping
{
    public class MappingProfiles : AutoMapper.Profile
    {
        public MappingProfiles()
        {
            CreateMap<CommentCreateDto, Comment>();
            CreateMap<CommentUpdateDto, Comment>();
            CreateMap<Comment, CommentDto>()
                .ForMember(d => d.DisplayName, o => o.MapFrom(s => s.User.DisplayName))
                .ForMember(d => d.Username, o => o.MapFrom(s => s.User.UserName))
                .ForMember(d => d.Image, o => o.MapFrom(s => 
                    s.User.Photos.FirstOrDefault(photo => photo.IsMain).Url));

            CreateMap<Media, MediaDto>().ReverseMap();
            CreateMap<Genre, GenreDto>().ReverseMap();
            CreateMap<MediaPhoto, MediaPhotoDto>().ReverseMap();
            CreateMap<Review, ReviewDto>().ReverseMap();
            CreateMap<ReviewRate, ReviewRateDto>().ReverseMap();
            CreateMap<MediaType, MediaTypeDto>().ReverseMap();

            CreateMap<AppUser, KinoKritic.BLL.Dtos.Profile>()
                .ForMember(d => d.Image, o => o.MapFrom(s => s.Photos.FirstOrDefault(photo => photo.IsMain).Url));
        }
    }
}