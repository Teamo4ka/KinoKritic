using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KinoKritic.DAL.Entities;
using Microsoft.AspNetCore.Identity;

namespace KinoKritic.DAL
{
    public class Seed
    {
        public static async Task SeedData(DataContext context,
            UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            string[] roleNames = { "Admin",  "Member" };
            foreach (var roleName in roleNames)
            {
                var roleExist = await roleManager.RoleExistsAsync(roleName);
                if (!roleExist)
                {
                    await roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
                
            var users = new List<AppUser>
            {
                new AppUser
                {
                    DisplayName = "Bob",
                    UserName = "bob",
                    Email = "bob@test.com",
                },
                new AppUser
                {
                    DisplayName = "Jane",
                    UserName = "jane",
                    Email = "jane@test.com",
                },
                new AppUser
                {
                    DisplayName = "Tom",
                    UserName = "tom",
                    Email = "tom@test.com",
                },
            };
            
            foreach (var user in users)
            {
                await userManager.CreateAsync(user, "Pa$$w0rd");

                if (user.UserName == "bob")
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
                await userManager.AddToRoleAsync(user, "Member");
            }

            var types = new List<MediaType>()
            {
                new MediaType()
                {
                    Name = "Series"
                },
                new MediaType()
                {
                    Name = "Movie"
                },
                new MediaType()
                {
                    Name = "Anime"
                },
                new MediaType()
                {
                    Name = "Anime/Series"
                },
                new MediaType()
                {
                    Name = "Cartoon"
                },
                new MediaType()
                {
                    Name = "Animated series"
                },
            };

            await context.MediaType.AddRangeAsync(types);


            var genres = new List<Genre>()
            {
                new Genre()
                {
                    Name = "SciFi"
                },
                new Genre()
                {
                    Name = "Fantasy"
                },
                new Genre()
                {
                    Name = "Comedy"
                },
                new Genre()
                {
                    Name = "Thriller"
                },
                new Genre()
                {
                    Name = "Romance"
                }
            };

            await context.Genres.AddRangeAsync(genres);

            var medias = new List<Media>()
            {
                new Media()
                {
                    Aged = 16,
                    Annotation = "Good annotation",
                    Budget = 777000000,
                    Composer = "George Lucas",
                    Country = "USA",
                    Director = "George Lucas",
                    Genres = new List<Genre>()
                    {
                        genres[2],
                        genres[4],
                    },
                    Type = types[1],
                    Name = "American Graffiti",
                    CreatedAt = new DateTime(1973, 1, 1)
                }
            };
            await context.Media.AddRangeAsync(medias);

            await context.SaveChangesAsync();
        }
    }
}