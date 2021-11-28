using System;

namespace KinoKritic.BLL.Dtos
{
    public class CommentUpdateDto
    {
        public Guid  Id { get; set; }

        public Guid ReviewId { get; set; }
        public string Body { get; set; } 
    }
}