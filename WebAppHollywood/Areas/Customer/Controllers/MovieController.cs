using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebAppHollywood.Areas.Customer.Controllers
{
    public class MovieController : Controller
    {
        // GET: Customer/Movie
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details()
        {
            return View();
        }
    }
}