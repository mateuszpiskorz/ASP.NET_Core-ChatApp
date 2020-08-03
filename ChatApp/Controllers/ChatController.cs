using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ChatApp.Helpers;
using ChatApp.Models;
using Newtonsoft.Json;

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
        public IActionResult ConversationWithContact(int contact)
        {
            if (SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user") == null)
            {
                return Json(new { status = "error", message = "User is not logged in" });
            }
            var currentUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");
            var conversations = new List<Conversations>();

            conversations = _context.Conversations.Where(c =>
            (c.ReceiverId == currentUser.Id && c.SenderId == contact) ||
            (c.ReceiverId == contact && c.SenderId == currentUser.Id))
            .OrderBy(c => c.CreatedTime)
            .ToList();

            return Json(new { status = "sucess", data = conversations });
        }

        [HttpPost]
        public IActionResult SendMessage()
        {
            if (SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user") == null)
            {
                return Json(new { status = "error", message = "User is not logged in" });
            }

            var currentUser = SessionHelper.GetObjectFromJson<User>(HttpContext.Session, "user");

            string socketId = Request.Form["socketId"];

            Conversations conv = new Conversations
            {
                SenderId = currentUser.Id,
                Message = Request.Form["message"],
                ReceiverId = Convert.ToInt32(Request.Form["contact"])
            };

            _context.Conversations.Add(conv);
            _context.SaveChanges();
            return Json(conv);
        }
    }
}
