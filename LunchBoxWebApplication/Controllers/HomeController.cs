using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LunchBoxWebApplication.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult ManageCategories()
        {
            return View();
        }

        public ActionResult ManageSubcategories()
        {
            return View();
        }

        public ActionResult ManageProducts()
        {
            return View();
        }

        public ActionResult ManageUsers()
        {
            return View();
        }

        public ActionResult ManagePayments()
        {
            return View();
        }

        public ActionResult OverviewOrders()
        {
            return View();
        }
    }
}
