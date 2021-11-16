using System;

namespace KinoKritic.DAL.Entities
{
    public class ReviewRate
    {
        public Guid Id { get; set; }
        public bool isLiked { get; set; }
        public Guid UserId { get; set; }
        public Guid ReviewId { get; set; }

        public AppUser User { get; set; }
        public Review Review { get; set; }
    }
}