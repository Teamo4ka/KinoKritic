using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace KinoKritic.DAL.Entities
{
    public class AppUser : IdentityUser
    {
        public string DisplayName { get; set; }
        public ICollection<UserPhoto> Photos { get; set; }
        public ICollection<Review> Reviews { get; set; }
        public ICollection<ReviewRate> ReviewRates { get; set; }
        public ICollection<Comment> Comments { get; set; }
    }
}