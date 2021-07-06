using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MayBeYouMissSomeNews.Models;

namespace MayBeYouMissSomeNews.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile()
        {
          
            return View();
        }
        [HttpGet]
        public ActionResult EditProfile(int id)
        {
            DBManagerContext context = new DBManagerContext();
            user user = context.users.SingleOrDefault(p => p.userid == id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        [HttpPost, ActionName("EditProfile")]
        public ActionResult EditProfile(user user)
        {
            DBManagerContext context = new DBManagerContext();
            user dbUpdate = context.users.FirstOrDefault(p => p.userid == user.userid);
            if (dbUpdate != null)
            {
                context.users.AddOrUpdate(user);
                context.SaveChanges();
            }
            return RedirectToAction("Profile");
        }
    }
}