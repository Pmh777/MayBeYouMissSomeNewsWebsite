using MayBeYouMissSomeNews.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MayBeYouMissSomeNews.Controllers
{
    public class CategoriesController : Controller
    {
        // GET: Categories
        public ActionResult List()
        {
            DBContext context = new DBContext();
            var listcategory = context.categories.ToList();
            return View(listcategory);
        }
        private DBContext db = new DBContext();
        public ActionResult DetailCategory(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            category category = db.categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);

        }
         
        public ActionResult TemporaryDeleteCategory(int id)
        {
            DBContext context = new DBContext();
            category dbUpdate = context.categories.FirstOrDefault(p => p.categoryid == id);
            return View(dbUpdate);
        }
        [Authorize]
        [HttpPost, ActionName("TemporaryDeleteCategory")]
        public ActionResult TemporaryDeleteCategory(FormCollection f)
        {
            DBContext context = new DBContext();
            var categoryid = Convert.ToInt32(f["categoryid"]);
            category dbUpdate = context.categories.FirstOrDefault(p => p.categoryid == categoryid);
            category u = dbUpdate;
            if (dbUpdate != null)
            {
                u.name = f["name"];
                u.status = 0;
                u.modifieddate = DateTime.Now;
                context.categories.AddOrUpdate(u);
                context.SaveChanges();
            }
            var list = context.categories.ToList();
            return View("List", u);
        }


        public ActionResult CreateCategory()
        {
            return View();

        }
        [HttpPost, ActionName("CreateCategory")]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCategory(FormCollection f)
        {
            DBContext context = new DBContext();
            string name = f["name"].ToString();
            category categoryInvalid = context.categories.SingleOrDefault(n => n.name == name);
            category u = new category();
            if (categoryInvalid == null)
            {
                u.name = f["name"].ToString();
                u.status =1;
                u.createdby = null;
                u.createddate = DateTime.Now;
                context.categories.Add(u);
                context.SaveChanges();
                var listcategory = context.categories.ToList();
                return View("List", listcategory);
            }
            return View();
        }
        public ActionResult EditCategory(int id)
        {
            DBContext context = new DBContext();
            category dbUpdate = context.categories.FirstOrDefault(p => p.categoryid == id);
            return View(dbUpdate);
        }
        [Authorize]
        [HttpPost, ActionName("EditCategory")]
        public ActionResult EditCategory(FormCollection f)
        {
            DBContext context = new DBContext();
            var categoryid = Convert.ToInt32(f["categoryid"]);
            category dbUpdate = context.categories.FirstOrDefault(p => p.categoryid == categoryid);
            category u = dbUpdate;
            if (dbUpdate != null)
            {
                u.name = f["name"];
                u.status = 1;
                u.modifieddate = DateTime.Now;
                context.categories.AddOrUpdate(u);
                context.SaveChanges();
            }
            var list = context.categories.ToList();
            return View("List", u);
        }
        public ActionResult ShowListcategory()
        {
            DBContext context = new DBContext();
            var listcategory = context.news.ToList();
            return View(listcategory);
        }
        public ActionResult ShowListcategorydetail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            news news = db.news.Find(id);
            if (news == null)
            {
                return HttpNotFound();
            }
            return View(news);

        }
    }
}