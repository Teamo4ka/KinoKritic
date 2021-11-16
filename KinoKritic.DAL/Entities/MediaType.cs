using System;
using System.Collections;
using System.Collections.Generic;

namespace KinoKritic.DAL.Entities
{
    public class MediaType
    {
        public Guid Id { get; set; }
        public string Name { get; set; }

        public ICollection<Media> Medias { get; set; }
    }
}