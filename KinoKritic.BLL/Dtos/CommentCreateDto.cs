using System;

namespace KinoKritic.BLL.Dtos
{
    public class CommentCreateDto
    {
        public string Body { get; set; }
        public Guid ReviewId { get; set; }
        public Guid MediaId { get; set; }
        public string UserId{ get; set; }
    }
}