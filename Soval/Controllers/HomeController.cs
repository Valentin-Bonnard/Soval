using Soval.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Threading.Tasks;
using System.Net.Mail;

namespace Soval.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.Show = true;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = " Jeune développeur en informatique (bac + 2), passionné,  curieux et tenace, je me suis porté à l'apprentissage"
               + " et l'approfondissement de mes compétence en C# puis de ces Framework dotNet et ASP.Net MVC (Razor view engine). "
               + "En parallèle, j'ai pratiqué le développement web (personnel) via le Html5/Css3, Javascript/Jquery.";

            ViewBag.Show = false;
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult Email()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Email(EmailModel C)
        {
            if (ModelState.IsValid)
            {
                var body = "<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>";
                var message = new MailMessage();
                message.To.Add(new MailAddress("dev.bonnard@gmail.com"));
                message.Subject = "Contact";
                message.Body = string.Format(body, C._name, C._email, C._subject, C._comment);
                message.IsBodyHtml = true;

                using (var smtp = new SmtpClient())
                {
                    await smtp.SendMailAsync(message);
                    return RedirectToAction("Success");
                }
            }
            ViewBag.Show = false;
            return View(C);
        }

        public ActionResult Success()
        {
            return View();
        }
    }
}