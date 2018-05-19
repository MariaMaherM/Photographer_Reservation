using PG_Project.Models;
using PG_Project.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PG_Project.Controllers;
using System.Net.Mail;
using System.Net;
using System.Text;

namespace PG_Project.Controllers
{
    public class HomeController : Controller
    {

        ProjectContext db = new ProjectContext();



        public ActionResult Index()
        {
            return View(db.PGs.ToArray());
        }

        public ActionResult RegisterPG()
        {
           
            return View();
        }


        [HttpPost]
        public ActionResult RegisterPG(PG pg)
        {
          //  pg.CategoryName = "~content/PG_img/" + pg.CategoryName.FileName;
           

            try
            {
                if (ModelState.IsValid)
                {
                    db.PGs.Add(pg);
                    db.SaveChanges();
                }
                return RedirectToAction("Login", "Login");
            }
            catch
            {
                return View();
            }
        }




        public ActionResult RegisterClient()
        {
          //  ViewData["NamePG"] = Enum.GetValues(typeof(PG)).Cast<PG>().Select(c => new SelectListItem { Text = c.ToString(), Value = c.ToString() });
            Client client = new Client();
            var pg = db.PGs.ToList();
            PhotographerClient pc = new PhotographerClient()
            {
                Client = client,
                photographers = pg

            };

            //var pg = db.PGs.ToList();
            //PhotographerClient pc = new PhotographerClient
            //{
            //    photographers= pg
            //};


            var get = db.PGs.ToList();
            SelectList list = new SelectList(get, "id", "User_Name");
            ViewBag.pg = list;

            return View(pc);
        }



        [HttpPost]
        public ActionResult RegisterClient(PhotographerClient cl)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    db.Clients.Add(cl.Client);
                    db.SaveChanges();
                }
                return RedirectToAction("Login", "Login");
            }
            catch
            {
                return View();
            }
        }



        public ActionResult ShowSpecificPG(int id)
        {



            var num = db.PGs.ToList().SingleOrDefault(c => c.id == id);

            return View(num);

        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }



        public JsonResult SendEmailToAdmin()
        {
            bool result = true;

            result = SendEmailAdmin("maria.maher48@yahoo.com", "acceptance", "<p>hi<br>thats my acceptance mail for you</p>");

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public bool SendEmailAdmin(string ToEmail, string Subject, String EmailBody)
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Host = "smtp.gmail.com";
                MailMessage mail = new MailMessage("yostinaateff@gmail.com", ToEmail, Subject, EmailBody);

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = true;
                SmtpServer.Credentials = new NetworkCredential("yostinaateff@gmail.com", "4102276RabnA");
                SmtpServer.EnableSsl = true;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = UTF8Encoding.UTF8;
                SmtpServer.Send(mail);


                return true;


            }

            catch (Exception ex)
            {
                return true;
            }

        }


        public JsonResult SendEmailToPG()
        {
            bool result = true;

            result = SendEmail("yostinaateff@gmail.com", "acceptance", "<p>hi<br>thats my acceptance mail for you</p>");

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public bool SendEmail(string ToEmail, string Subject, String EmailBody)
        {
            try
            {
                SmtpClient SmtpServer = new SmtpClient();
                SmtpServer.Host = "smtp.gmail.com";
                MailMessage mail = new MailMessage("christinemagdy07@gmail.com", ToEmail, Subject, EmailBody);

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = true;
                SmtpServer.Credentials = new NetworkCredential("yostinaateff@gmail.com", "4102276RabnA");
                SmtpServer.EnableSsl = true;
                mail.IsBodyHtml = true;
                mail.BodyEncoding = UTF8Encoding.UTF8;
                SmtpServer.Send(mail);

                return true;

            }

            catch (Exception ex)
            {
                return false;
            }
        }





    }
}