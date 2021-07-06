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

        [HttpPost, ActionName("Login")]
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

        [HttpPost, ActionName("Register")]
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
                    ViewBag.Status = "Email dã được đăng ký!";
                    return View();
                }
            }



        }
        public ActionResult Logout()
        {
            Session["Account"] = null;
            return RedirectToAction("Index");
        }
        // GET: Accounts
        [HttpGet]
        public ActionResult LoginAdmin()
        {
            return View();
        }

        [HttpPost, ActionName("LoginAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult LoginAdmin(FormCollection f)
        {
            // check username and password
            DBManagerContext context = new DBManagerContext();
            string user = f["email"].ToString();
            string pass = f["password"].ToString();

            employee u = context.employees.SingleOrDefault(n => n.gmail == user && n.password == pass);
            //if user input right account, show homepage(index)
            if (u == null)
            {
                ViewBag.Status = "Tài Khoản hoặc Mật Khẩu không đúng!";
                return View();
            }
            else
            {

                Session["AccountAdmin"] = u;
                return RedirectToAction("Index", "Home");
            }
            //back to login
            // return View();
        }
        public ActionResult RegisterAdmin()
        {
            return View();
        }

        [HttpPost, ActionName("RegisterAdmin")]
        [ValidateAntiForgeryToken]

        public ActionResult RegisterAdmin(FormCollection f)
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
                employee employeeInvalid = context.employees.SingleOrDefault(n => n.gmail == gmail);
                employee u = new employee();
                if (employeeInvalid == null)
                {
                    u.name = f["name"].ToString();
                    u.gmail = f["email"].ToString();
                    u.birthday = System.Convert.ToDateTime(f["birthday"]);
                    u.password = f["password"].ToString();
                    u.status = 1;
                    u.gender = 1;
                    u.type = 1;
                    u.createddate = DateTime.Now;
                    u.createdby = null;
                    u.modifiedby = null;
                    u.modifieddate = null;
                    u.photo = null;
                    context.employees.Add(u);
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
        public ActionResult ChangepasswordAdmin()
        {
            return View();
        }

        [HttpPost, ActionName("ChangepasswordAdmin")]
        [ValidateAntiForgeryToken]
        public ActionResult ChangepasswordAdmin(FormCollection f)
        {
            string pass = f["password"].ToString();
            string newpass = f["newpassword"].ToString();
            string renewpass = f["renewpassword"].ToString();
            if (newpass != renewpass || pass == newpass || pass == renewpass)
            {
                ViewBag.Status = "Mật khẩu không khớp nhau!";
                return View();
            }
            else
            {
                DBManagerContext context = new DBManagerContext();
                string gmail = f["email"].ToString();
                employee employeeInvalid = context.employees.SingleOrDefault(n => n.password == pass && n.gmail == gmail);
                employee u = new employee();
                if (employeeInvalid != null)
                {
                    u.password = f["newpassword"].ToString();
                    context.employees.Add(u);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
                return View();
            }
        }
        public ActionResult LogoutAdmin()
        {
            Session["AccountAdmin"] = null;
            return RedirectToAction("Index");
        }
    }
}