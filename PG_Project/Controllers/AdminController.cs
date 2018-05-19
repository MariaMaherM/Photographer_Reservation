using PG_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace PG_Project.Controllers
{
    public class AdminController : Controller
    {
        ProjectContext db = new ProjectContext();

        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult ShowPG()
        {
            return View(db.PGs.ToList());
        }




        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {

            var pg = db.PGs.ToList().SingleOrDefault(c => c.id == id);
            return View(pg);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5



        public ActionResult Edit(int id = 1)
        {
            Admin adm = db.Admins.Single(x => x.id == id);

            return View(adm);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Admin adm)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(adm).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("WelcomeAdmin", "Login");
            }
            catch
            {
                return View("WelcomeAdmin", "Login");
            }
        }




        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            PG pg = db.PGs.Single(x => x.id == id);
            return View(pg);
        }

        // POST: Admin/Delete/5
        [HttpPost , ActionName("Delete")]
        public ActionResult Delete( PG pg)
        {
            try
            {
                // TODO: Add delete logic here
               pg = db.PGs.Find(pg.id);
                db.PGs.Remove(pg);
                db.SaveChanges();
                return RedirectToAction("WelcomeAdmin","Login");
            }
            catch
            {
                return View("WelcomeAdmin", "Login");
            }
        }













        public void CheckEmail(Admin adm)
        {
            if (ModelState.IsValid)
            {
                var details = (from userlist in db.Admins
                               where userlist.User_Name == adm.User_Name && userlist.Password == adm.Password
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
