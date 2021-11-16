using System.Threading.Tasks;
using KinoKritic.DAL.Entities;

namespace KinoKritic.BLL.Interfaces
{
    public interface ITokenService
    {
        Task<string> CreateToken(AppUser user);
    }
}