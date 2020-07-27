using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Models;
using ChatApp.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace ChatApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly ChatDbContext _context;
        public AuthController(ChatDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login()
        {
            string user_name = Request.Form["username"];

            if (user_name.Trim() == "")
            {
                return Redirect("/");
            }

            User user = _context.User.FirstOrDefault(u => u.Name == user_name);

            if (user == null)
            {
                user = new User() { Name = user_name };
                _context.User.Add(user);
                _context.SaveChanges();
            }
            SessionHelper.SetObjectAsJson(HttpContext.Session, "user", user);
            return Redirect("/chat");
        }
    }
}
