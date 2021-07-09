using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MayBeYouMissSomeNews.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult List()
        {
            return View();
        }
    }
}