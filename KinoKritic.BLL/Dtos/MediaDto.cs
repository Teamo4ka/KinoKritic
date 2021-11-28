using System;
using System.Collections.Generic;
using KinoKritic.DAL.Entities;

namespace KinoKritic.BLL.Dtos
{
    public class MediaDto
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
        public MediaTypeDto Type { get; set; }
        public string PhotoUrl{ get; set; }
        public ICollection<MediaPhotoDto> Photos { get; set; } = new List<MediaPhotoDto>();
        public ICollection<ReviewDto> Reviews { get; set; }
        public ICollection<GenreDto> Genres { get; set; }
    }
}