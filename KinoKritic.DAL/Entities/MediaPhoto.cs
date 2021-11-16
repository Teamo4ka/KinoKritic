using System;

namespace KinoKritic.DAL.Entities
{
    public class MediaPhoto
    {
        public Guid Id { get; set; }
        public string Url { get; set; }
        public Guid MediaId { get; set; }
        public bool IsMain { get; set; }

        public Media Media { get; set; }
    }
}