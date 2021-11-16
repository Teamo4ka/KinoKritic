using System;

namespace KinoKritic.DAL.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Body { get; set; }
        public string UserId { get; set; }
        public Guid ReviewId { get; set; }
        public DateTime CreatedAt { get; set; }

        public AppUser User { get; set; }
        public Review Review { get; set; }
    }
}