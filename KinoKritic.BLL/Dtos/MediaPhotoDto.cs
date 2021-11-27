using System;

namespace KinoKritic.BLL.Dtos
{
    public class MediaPhotoDto
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public bool IsMain { get; set; }
    }
}