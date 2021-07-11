using MayBeYouMissSomeNews.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
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
                u.status = 1;
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
            category categoryEdit = context.categories.FirstOrDefault(p => p.categoryid == id);
            return View(categoryEdit);
        }
        [Authorize]
        [HttpPost, ActionName("EditCategory")]
        public ActionResult Edit(category category)
        {
            DBContext context = new DBContext();
            category categoryEdit = context.categories.FirstOrDefault(p => p.categoryid == category.categoryid);
            category u = new category();
            if (categoryEdit != null)
            {
                context.categories.AddOrUpdate(category);
                context.SaveChanges();
            }
            var list = context.categories.ToList();
            return View("List", list);
        }
    }
}