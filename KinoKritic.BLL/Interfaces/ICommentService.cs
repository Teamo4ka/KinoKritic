using System.Threading.Tasks;
using KinoKritic.BLL.Dtos;
using KinoKritic.DAL.Entities;

namespace KinoKritic.BLL.Interfaces
{
    public interface ICommentService
    {
        Task CreateComment(CommentCreateDto createDto);
    }
}