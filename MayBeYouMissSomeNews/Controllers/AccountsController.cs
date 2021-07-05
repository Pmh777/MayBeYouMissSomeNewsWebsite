using MayBeYouMissSomeNews.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MayBeYouMissSomeNews.Controllers
{
    public class AccountsController : Controller
    {
        // GET: Accounts
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }
       
        [HttpPost,ActionName("Login")]
        [ValidateAntiForgeryToken]
        public ActionResult Login(FormCollection f)
        {
            // check username and password
            DBManagerContext context = new DBManagerContext();
            string user = f["email"].ToString();
            string pass = f["password"].ToString();

            user u = context.users.SingleOrDefault(n => n.gmail == user && n.password == pass);
            //if user input right account, show homepage(index)
            if (u != null)
            {
                Session["Account"] = u;
                return RedirectToAction("Index", "Home");
            }
            else
            
             //back to login
            return View();
        }
        public ActionResult Register()
        {
            return View();
        }
       
        [HttpPost,ActionName("Register")]
        [ValidateAntiForgeryToken]
       
        public ActionResult Register(FormCollection f)
        {
            string pass = f["password"].ToString();
            string repass = f["repassword"].ToString();
            if (pass != repass)
            {
                ViewBag.Status = "Mật khẩu không khớp nhau!";
                return View();
            }
            else
            {
                DBManagerContext context = new DBManagerContext();
                string gmail = f["email"].ToString();
                user userInvalid = context.users.SingleOrDefault(n => n.gmail == gmail);
                user u = new user();
                if (userInvalid == null)
                {
                    u.name = f["name"].ToString();
                    u.gmail = f["email"].ToString();
                    u.password = f["password"].ToString();
                    u.status = 1;
                    u.createddate = DateTime.Now;
                    u.modifieddate = null;
                    u.photo = null;
                    context.users.Add(u);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Status = "Email đã được đăng ký!";
                    return View();
                }
            }
            


        }
        public ActionResult Logout()
        {
            Session["Account"] = null;
            return RedirectToAction("Index");
        }
    }
}