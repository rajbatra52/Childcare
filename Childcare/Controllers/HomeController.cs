using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Childcare.Models;

namespace Childcare.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult About()
        {
            ViewBag.Message = "Childcare";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact Details";

            return View();
        }

        public ActionResult Childcare()
        {
            ViewBag.Message = "Childcare Details";

            return View();
        }

        public ActionResult MyView()
        {
            ViewBag.Message = "This is my view";

            return View();
        }

        public ActionResult MyViewHelper()
        {
            ViewBag.Message = "This is my view";
            Child objChild = new Child();//Creates an object of Child class using default constructor
            objChild.childid = 1;
            objChild.childname = "Joe";
            //objChild.childdob = "2015-10-09";
            return View(objChild);
        }

        public ActionResult MyViewHelper1()
        {
            ViewBag.Message = "This is my view";
            Child objChild = new Child();
            objChild.childid = 1;
            objChild.childname = "Joe";
            //objChild.childdob = "2015-10-09";
            return View(objChild);
        }

        public ActionResult MyViewHelper2()
        {
            ViewBag.Message = "This is my view";
            Child objChild = new Child();
            objChild.childid = 1;
            objChild.childname = "Joe";
            //objChild.childdob = "2015-10-09";
            return View(objChild);
        }
    }
}