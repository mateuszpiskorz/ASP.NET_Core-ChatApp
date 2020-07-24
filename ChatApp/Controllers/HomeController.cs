using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (Session["user"] != null) return Redirect("/chat");

            return View();
        }
    }
}
