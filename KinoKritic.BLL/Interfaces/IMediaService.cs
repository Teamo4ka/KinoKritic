using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinoKritic.BLL.Dtos;

namespace KinoKritic.BLL.Interfaces
{
    public interface IMediaService
    {
        public Task<IEnumerable<MediaDto>> GetAllAsync();
        public Task<MediaDto> GetByIdAsync(Guid id);

        public Task CreateAsync(MediaDto mediaForCreation);
    }
}