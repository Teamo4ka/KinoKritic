using System.Threading.Tasks;
using AutoMapper;
using KinoKritic.BLL.Dtos;
using KinoKritic.BLL.Interfaces;
using KinoKritic.DAL;
using KinoKritic.DAL.Entities;

namespace KinoKritic.BLL.Services
{
    public class CommentService : ICommentService
    {
        private readonly DataContext _context;
        private readonly IUserAccessor _userAccessor;
        private readonly IMapper _mapper;

        public CommentService(DataContext context, IMapper mapper, IUserAccessor userAccessor)
        {
            _context = context;
            _mapper = mapper;
            _userAccessor = userAccessor;
        }

        public async Task CreateComment(CommentCreateDto createDto)
        {
            var user = await _context.Users.FindAsync(_userAccessor.GetUserId());
            var comment = _mapper.Map<Comment>(createDto);
            comment.User = user;
            _context.Add(comment);
            await _context.SaveChangesAsync();
        }
    }
}