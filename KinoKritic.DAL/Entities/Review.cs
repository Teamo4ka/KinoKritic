using System;
using System.Collections;
using System.Collections.Generic;

namespace KinoKritic.DAL.Entities
{
    public class Review
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public double Rate { get; set; }
        public Guid MediaId { get; set; }
        public Guid UserId { get; set; }

        public AppUser User { get; set; }
        public Media Media { get; set; }
        public ICollection<ReviewRate> Rates { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}