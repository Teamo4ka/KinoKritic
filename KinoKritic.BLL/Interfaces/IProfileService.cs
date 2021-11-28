using System.Threading.Tasks;
using KinoKritic.BLL.Dtos;


namespace KinoKritic.BLL.Interfaces
{
    public interface IProfileService
    {
        Task<Profile> GetProfile(string userId);
        Task SetPhoto(string userId, string url);
    }
}