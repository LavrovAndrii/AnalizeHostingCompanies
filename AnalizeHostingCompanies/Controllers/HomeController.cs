using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnalizeHostingCompanies.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Головна сторінка.";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Сторінка з описом про проект.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Контактна інформація.";

            return View();
        }
    }
}