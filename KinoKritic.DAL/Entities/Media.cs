using System;
using System.Collections;
using System.Collections.Generic;

namespace KinoKritic.DAL.Entities
{
    public class Media
    {
        public Guid MediaId { get; set; }
        public Guid TypeId { get; set; }
        public string Annotation { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Country { get; set; }
        public string Director{ get; set; }
        public string Scenario{ get; set; }
        public string Operator{ get; set; }
        public string Composer{ get; set; }
        public decimal Budget{ get; set; }
        public int Aged { get; set; }
        public string Trailer { get; set; }
        public double Rated { get; set; }
        public DateTime CreatedAt { get; set; }
        public MediaType Type { get; set; }
        public ICollection<MediaPhoto> Photos { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<Genre> Genres { get; set; }
    }
}