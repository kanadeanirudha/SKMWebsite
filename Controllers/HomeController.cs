using System.Configuration;
using System.Net.Mail;
using System.Net;
using System;
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
        [HttpPost]
        public ActionResult SendEmail(ContactUsViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var senderEmail = new MailAddress(ConfigurationManager.AppSettings["MailFrom"].ToString(), ConfigurationManager.AppSettings["MailFrom_Name"].ToString());
                    var receiverEmail = new MailAddress(model.Email, model.Name);
                    var password = ConfigurationManager.AppSettings["Password"].ToString();
                    var sub = model.Name + " wants to connect with you";
                    var body = string.Format(@"Name :{0} 
                                 Phone: {1}
                                 Email : {2}
                                 Message : {3}", model.Name, model.PhoneNumber, model.Email, model.Message);
                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(senderEmail.Address, password)
                    };
                    using (var mess = new MailMessage(senderEmail, receiverEmail)
                    {
                        Subject = sub,
                        Body = body
                    })
                    {
                        smtp.Send(mess);
                        TempData["success"] = "Thank you for contacting us...";
                    }
                    return RedirectToAction(nameof(ContactUs));
                }
            }
            catch (Exception ex)
            {

            }
            TempData["error"] = "Failed to connect, Kindly verify the details";
            return RedirectToAction(nameof(ContactUs));
        }
    }
}