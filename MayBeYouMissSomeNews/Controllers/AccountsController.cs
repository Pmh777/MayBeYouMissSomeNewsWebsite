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
            DBContext context = new DBContext();
            string user = f["email"].ToString();
            string pass = f["password"].ToString();


            user u = context.users.SingleOrDefault(n => n.email == user);
            if (u != null)
            {
                string hashpass = u.password;
                Boolean checkPass = BCrypt.Net.BCrypt.Verify(pass, hashpass);
                //if user input right account, show homepage(index)
                if (checkPass)
                {
                    Session["Account"] = u;
                    return RedirectToAction("Index", "Home");
                }
                else

                    //back to login
                    return View();
            }
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
                DBContext context = new DBContext();
                string gmail = f["email"].ToString();
                user userInvalid = context.users.SingleOrDefault(n => n.email == gmail);
                user u = new user();
                if (userInvalid == null)
                {
                    u.name = f["name"].ToString();
                    u.email = f["email"].ToString();
                    // encrypt password by BCrypt
                    u.password = BCrypt.Net.BCrypt.HashPassword(f["password"].ToString(), 12);
                    u.status = 1;
                    u.createddate = DateTime.Now;
                    u.modifieddate = null;
                    u.photo = "defaultAvatar.png";
                    context.users.Add(u);
                    context.SaveChanges();
                    Session["Account"] = u;
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
            return RedirectToAction("Index","Home");
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
            DBContext context = new DBContext();
            string username = f["email"].ToString();
            string pass = f["password"].ToString();
            employee u = context.employees.SingleOrDefault(n => n.email == username);
            if (u != null)
            {
                string hashpass = u.password;
                Boolean checkPass = BCrypt.Net.BCrypt.Verify(pass, hashpass);
                //if user input right account, show homepage(index)
                if (checkPass)
                {
                    Session["AccountAdmin"] = u;
                    return RedirectToAction("Dashboard", "Home");
                }
                else

                    //back to login
                    return View();
            }
            return View();
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
                DBContext context = new DBContext();
                string email = f["email"].ToString();
                employee employeeInvalid = context.employees.SingleOrDefault(n => n.email == email);
                employee u = new employee();
                if (employeeInvalid == null)
                {
                    u.name = f["name"].ToString();
                    u.email = f["email"].ToString();
                    u.birthday = System.Convert.ToDateTime(f["birthday"]);
                    u.password = BCrypt.Net.BCrypt.HashPassword(f["password"].ToString(), 12);
                    u.status = 0;
                    u.gender = null;
                    u.type = 0;
                    u.phone = f["phone"].ToString();
                    u.address = f["address"].ToString();
                    u.createddate = DateTime.Now;
                    u.createdby = null;
                    u.modifiedby = null;
                    u.modifieddate = null;
                    u.photo = "defaultAvatar.png";
                    context.employees.Add(u);
                    context.SaveChanges();
                    ViewBag.Status = "Đăng kí thành công!Vui lòng chờ xét duyệt!";
                    return View();
                }
                else
                {
                    ViewBag.Status = "Email đã được đăng ký!";
                    return View("");
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
                DBContext context = new DBContext();
                string email = f["email"].ToString();
                employee employeeInvalid = context.employees.SingleOrDefault(n => n.password == pass && n.email == email);
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
            return RedirectToAction("LoginAdmin","Home");
        }
        
    }
}