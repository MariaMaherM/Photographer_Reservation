using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PG_Project.Controllers;
using PG_Project.Models;
using PG_Project.ViewModel;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Data.Entity;

namespace PG_Project.Controllers
{
    public class PhotographerController : Controller
    {
        ProjectContext db = new ProjectContext();




        // GET: Photographer
        public ActionResult PgProfile()
        {
            return View(db.PGs.ToList());
        }

        // GET: Photographer/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }




       




        // GET: Photographer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Photographer/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }






       





       

        public ActionResult Delete(int id)
        {
            Client cl = db.Clients.Single(x => x.id == id);
            return View(cl);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult Delete(Client cl)
        {
            try
            {
                // TODO: Add delete logic here
                cl = db.Clients.Find(cl.id);
                db.Clients.Remove(cl);
                db.SaveChanges();
                return RedirectToAction("WelcomePG", "Login");
            }
            catch
            {
                return View("WelcomePG", "Login");
            }
        }








        public void CheckEmail(PG pg)
        {
            if (ModelState.IsValid)
            {
                var details = (from userlist in db.PGs
                               where userlist.User_Name == pg.User_Name && userlist.Password == pg.Password
                               select new
                               {

                                   userlist.Email,
                                   userlist.id,

                               }).ToList();




                if (details.FirstOrDefault() != null)
                {
                    Session["id"] = details.FirstOrDefault().id;
                    Session["Email"] = details.FirstOrDefault().Email;

                }


            }

        }




        public JsonResult SendEmailToUser()
        {
            bool result = true;

            result = SendEmail("christinemagdy07@gmail.com", "acceptance", "<p>hi<br>thats my acceptance mail for you</p>");

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public bool SendEmail(string ToEmail, string Subject, String EmailBody)
        {

            SmtpClient SmtpServer = new SmtpClient();
            SmtpServer.Host = "smtp.gmail.com";
            MailMessage mail = new MailMessage("mariamaher86@gmail.com", ToEmail, Subject, EmailBody);

            SmtpServer.Port = 587;
            SmtpServer.UseDefaultCredentials = true;
            SmtpServer.Credentials = new NetworkCredential("mariamaher86@gmail.com", "01273395379");
            SmtpServer.EnableSsl = true;
            mail.IsBodyHtml = true;
            mail.BodyEncoding = UTF8Encoding.UTF8;
            SmtpServer.Send(mail);

            return true;




        }







    }
}
