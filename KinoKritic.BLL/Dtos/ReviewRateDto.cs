using System;

namespace KinoKritic.BLL.Dtos
{
    public class ReviewRateDto
    {
        public Guid Id { get; set; }
        public bool isLiked { get; set; }
        public string UserId { get; set; }
        public Guid ReviewId { get; set; }
    }
}