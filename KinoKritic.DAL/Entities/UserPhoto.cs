using System;

namespace KinoKritic.DAL.Entities
{
    public class UserPhoto
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public string UserId { get; set; }

        public AppUser User { get; set; }
    }
}