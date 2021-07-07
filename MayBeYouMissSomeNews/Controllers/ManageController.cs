using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MayBeYouMissSomeNews.Controllers
{
    public class ManageController : Controller
    {
        // GET: Managed
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult RegisterSuccess()
        {
            return View();
        }
    }
}