using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ChatApp.Helpers;
using ChatApp.Models;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (SessionHelper.GetObjectFromJson<User>(HttpContext.Session,"user") != null) return Redirect("/chat");

            return View();
        }
    }
}
