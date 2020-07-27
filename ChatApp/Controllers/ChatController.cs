using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Helpers;
using ChatApp.Models;

namespace ChatApp.Controllers
{
    public class ChatController:Controller
    {
        private readonly ChatDbContext _context;
        public ChatController(ChatDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            if (SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user") == null)
            {
                return Redirect("/");
            }

            var currentUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");

            ViewBag.allUsers = _context.User.Where(u => u.Name != currentUser.Name).ToList();
            ViewBag.currentUser = currentUser;
            return View();

        }
    }
}
