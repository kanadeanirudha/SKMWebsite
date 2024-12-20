﻿using System.Web.Mvc;

namespace SKMWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult OurServices()
        {
            return View();
        }
        public ActionResult Calculator(string loanType = null)
        {
            loanType = string.IsNullOrEmpty(loanType) ? "home" : loanType;
            return View("~/Views/Home/Calculator.cshtml", null, loanType);
        }
        public ActionResult Downloads()
        {
            return View();
        }
        public ActionResult Reviews()
        {
            return View();
        }

        public ActionResult ContactUs()
        {
            return View();
        }
    }
}