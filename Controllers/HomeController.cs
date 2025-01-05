using System.Web.Mvc;

namespace SKMWebsite.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Active = "home";
            return View();
        }

        public ActionResult AboutUs()
        {
            ViewBag.Active = "AboutUs";
            return View();
        }
        public ActionResult OurServices()
        {
            ViewBag.Active = "OurServices";
            return View();
        }
        public ActionResult Calculator(string loanType = null)
        {
            ViewBag.Active = "Calculator";
            loanType = string.IsNullOrEmpty(loanType) ? "home" : loanType;
            return View("~/Views/Home/Calculator.cshtml", null, loanType);
        }
        public ActionResult Downloads()
        {
            ViewBag.Active = "Downloads";
            return View();
        }
        public ActionResult Reviews()
        {
            ViewBag.Active = "Reviews";
            return View();
        }

        public ActionResult ContactUs()
        {
            ViewBag.Active = "ContactUs";
            return View();
        }
    }
}