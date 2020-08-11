using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Models;

namespace ChatApp.Controllers
{
    public class RegController : Controller
    {
        
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User model)
        {
            model.CreateTime = DateTime.Today;

            return Redirect("/chat");
        }
    }
}
