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




        public JsonResult SendEmailToUser(string y)
        {
            bool result = false;
            //da el mota3'air
            result = SendEmail(y, "acceptance", "<p>hi<br>thats my acceptance mail for you</p>");

            return Json(result, JsonRequestBehavior.AllowGet);

        }

        public bool SendEmail(string ToEmail, string Subject, string EmailBody)
        {
            try
            {
                string SenderEmail = System.Configuration.ConfigurationManager.AppSettings["mariamaher86 @gmail.com"].ToString();
                string SenderPass = System.Configuration.ConfigurationManager.AppSettings[""].ToString();
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 100000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential(SenderEmail, SenderPass);
                MailMessage msg = new MailMessage(SenderEmail, ToEmail, Subject, EmailBody);
                msg.IsBodyHtml = true;
                msg.BodyEncoding = UTF8Encoding.UTF8;
                client.Send(msg);
                return true;
            }

            catch (Exception Ex)
            {
                return false;
            }

        }
    }
}










