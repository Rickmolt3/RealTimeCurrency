using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RealTimeCurrency.Controllers
{
    public class HomeController : Controller
    {
        //entry point of the application 
        public ActionResult Index()
        {
            return View();
        }

        //controller for the about view
        public ActionResult About()
        {
            return View();
        }

        //controller for the contact view
        public ActionResult Contact()
        {
            return View();
        }
    }
}