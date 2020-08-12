using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChatApp.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace ChatApp.Controllers
{
    public class UserController : Controller
    {

        private ChatDbContext db;

        public UserController(IServiceProvider service)
        {
            db = new ChatDbContext(service.GetRequiredService<DbContextOptions<ChatDbContext>>());

        }
        public IActionResult Index()
        {
            var users = from u in db.User
                        orderby u.Id
                        select u;
            return View(users);
        }
    }
}
