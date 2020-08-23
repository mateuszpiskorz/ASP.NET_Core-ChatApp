using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;


namespace ChatApp.Seeders
{
    public static class UserDbSeeder
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var db = new ChatDbContext(serviceProvider.GetRequiredService<DbContextOptions<ChatDbContext>>()))
            {
                if (db.User.Any())
                {
                    return;
                }

                db.User.AddRange(
                    new User
                    {
                        Name = "Harry",
                        Password = "1212",
                        Mail = "hpotter@hogwart.com",
                        CreateTime = DateTime.Today

                    },
                    new User
                    {
                        Name = "Derek",
                        Password = "1212",
                        Mail = "derek@mymail.com",
                        CreateTime = DateTime.Today

                    },
                    new User
                    {
                        Name = "Andrew",
                        Password = "1212",
                        Mail = "ajonsons@hogwart.com",
                        CreateTime = DateTime.Today

                    },
                    new User
                    {
                        Name = "Harry",
                        Password = "1212",
                        Mail = "hpotter@hogwart.com",
                        CreateTime = DateTime.Today

                    });

                db.SaveChanges();
            }


        }
    }
}
