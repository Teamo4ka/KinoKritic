using System;
using System.Collections.Generic;

namespace KinoKritic.BLL.Dtos
{
    public class ReviewDto
    {
        public Guid Id { get; set; }
        public string Text { get; set; }
        public string Title { get; set; }
        public double Rate { get; set; }

        public ICollection<ReviewRateDto> Rates { get; set; }
        public ICollection<CommentDto> Comments { get; set; }
    }
}