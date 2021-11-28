using Microsoft.AspNetCore.Http;
namespace KinoKritic.BLL.Interfaces
{
    public interface IUserAccessor
    {
        string GetUserId();
    }
}