using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class ChatDbContext : DbContext
    {

        public ChatDbContext()
        {

        }

        public static ChatDbContext Create()
        {
            return new ChatDbContext();
        }

        public DbSet<User> Users { get; set; }

    }
}
