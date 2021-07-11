using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MayBeYouMissSomeNews.Controllers
{
    public class NewsController : Controller
    {
        // GET: News
        public ActionResult List()
        {
            return View();
        }
        public ActionResult AddNews()
        {
            return View();
        }
    }
}