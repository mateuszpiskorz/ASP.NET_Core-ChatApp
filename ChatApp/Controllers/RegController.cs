using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ChatApp.Controllers
{
    public class RegController : Controller
    {
        IServiceProvider _service;
        public RegController(IServiceProvider service)
        {
            _service = service;

        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(User model)
        {
            using (var db = new ChatDbContext (_service.GetRequiredService<DbContextOptions<ChatDbContext>>()))
            {
                if (ModelState.IsValid)
                {
                    try
                    {
                        model.CreateTime = DateTime.Today;
                        await db.User.AddAsync(model);
                        await db.SaveChangesAsync();
                        return Redirect("/chat");
                    }
                    catch
                    {
                        Debug.WriteLine("Cannot save model to DB.");
                        return View();
                    }


                }
                else return View();
                


            }

                

            
        }
    }
}
