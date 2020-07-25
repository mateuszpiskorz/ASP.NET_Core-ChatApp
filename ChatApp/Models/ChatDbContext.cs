using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Models
{
    public class ChatDbContext : DbContext
    {
        public string ConnectionString { get; set; }
        public ChatDbContext(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
         
    }
}
