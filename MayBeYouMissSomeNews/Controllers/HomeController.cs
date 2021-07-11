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
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult AdminProfile()
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
            DBContext context = new DBContext();
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
            DBContext context = new DBContext();
            user dbUpdate = context.users.FirstOrDefault(p => p.userid == user.userid);
            if (dbUpdate != null)
            {
                context.users.AddOrUpdate(user);
                context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult EditProfileAdmin(int id)
        {
            DBContext context = new DBContext();
            employee dbUpdate = context.employees.SingleOrDefault(p => p.employeeid == id);
            if (dbUpdate == null)
            {
                return HttpNotFound();
            }
            return View(dbUpdate);
        }
        [HttpPost, ActionName("EditProfileAdmin")]
        public ActionResult EditProfileAdmin(FormCollection employee)
        {
            DBContext context = new DBContext();
            var employeeId = Convert.ToInt32(employee["employeeid"]);
            employee dbUpdate = context.employees.FirstOrDefault(p => p.employeeid ==employeeId);

            employee u = dbUpdate;
            if (dbUpdate != null)
            {
      
                u.name = employee["name"];
                u.email = employee["email"]; 
                u.birthday = Convert.ToDateTime(employee["birthday"]);
                u.status = 1;
                u.gender = 1;
                u.type = 1;
                u.phone = employee["phone"];
                u.address = employee["address"];
                u.createddate = DateTime.Now;
                u.createdby = null;
                u.modifiedby = null;
                u.modifieddate = null;
                u.photo = null;
                context.employees.AddOrUpdate(u);
                context.SaveChanges();
            }
            var list = context.employees.ToList();
            return View("Dashboard", u);
        }
    }
}