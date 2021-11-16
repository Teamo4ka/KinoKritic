using System;
using KinoKritic.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace KinoKritic.DAL
{
    public class DataContext : IdentityDbContext<AppUser>
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        public DbSet<AppUser> Users { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<MediaPhoto> MediaPhotos { get; set; }
        public DbSet<MediaType> MediaType { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ReviewRate> ReviewRates { get; set; }
        public DbSet<UserPhoto> UserPhotos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<UserPhoto>()
                .HasOne(p => p.User)
                .WithMany(u => u.Photos)
                .HasForeignKey(p => p.UserId);

            builder.Entity<ReviewRate>()
                .HasOne(r => r.User)
                .WithMany(u => u.ReviewRates)
                .HasForeignKey(r => r.UserId);

            builder.Entity<ReviewRate>()
                .HasOne(r => r.Review)
                .WithMany(r => r.Rates)
                .HasForeignKey(r => r.ReviewId);
            
            builder.Entity<Comment>()
                .HasOne(r => r.User)
                .WithMany(u => u.Comments)
                .HasForeignKey(r => r.UserId);

            builder.Entity<Comment>()
                .HasOne(r => r.Review)
                .WithMany(r => r.Comments)
                .HasForeignKey(r => r.ReviewId);

            builder.Entity<Review>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.UserId);
            
            builder.Entity<Review>()
                .HasOne(r => r.Media)
                .WithMany(u => u.Reviews)
                .HasForeignKey(r => r.MediaId);

            builder.Entity<Media>()
                .HasOne(m => m.Type)
                .WithMany(t => t.Medias)
                .HasForeignKey(m => m.TypeId);
            
            builder.Entity<MediaPhoto>()
                .HasOne(m => m.Media)
                .WithMany(m => m.Photos)
                .HasForeignKey(m => m.MediaId);

        }
    }
}