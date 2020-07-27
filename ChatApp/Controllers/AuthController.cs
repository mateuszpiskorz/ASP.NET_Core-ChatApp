using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace ChatApp.Controllers
{
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Login()
        {
            string user_name = Request.Form["username"];

            if (user_name.Trim() == "")
            {
                return Redirect("/");
            }
            using (var db = new Models.ChatDbContext(options=> options.GetConnection))
            {

            }
        }
    }
}
