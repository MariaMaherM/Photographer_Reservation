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
using System.IO;

namespace PG_Project.Controllers
{
    public class HomeController : Controller
    {

        ProjectContext db = new ProjectContext();


        public ActionResult Index()
        {
            return View(db.PGs.ToList());
        }


        public ActionResult Details(int id,string name  )
        {

            var pg = db.PGs.ToList().SingleOrDefault(c => c.id == id);
            ViewBag.name = name;
            return View(pg);
        }


        public ActionResult RegisterPG()
        {
           
            return View();
        }
        



        [HttpPost]
        public ActionResult RegisterPG(PG pg)
        { 

            //pg.photo = new byte[File1.ContentLength]; // file1 to store image in binary formate  

            //File1.InputStream.Read(pg.photo, 0, File1.ContentLength);

            // pg.CategoryName = "~content/PG_img/" + pg.CategoryName.FileName;


            // pg.CategoryName = new byte[image1.ContentLength];

            //string fileName = Path.GetFileNameWithoutExtension(pg.file.FileName);

            //string extension = Path.GetExtension(pg.file.FileName);
            //fileName = fileName + DateTime.Now.ToString("yymmssfff") + extension;
            //pg.Status = "~/Image/" + fileName;
            //fileName = Path.Combine(Server.MapPath("~/Image/"), fileName);
            //pg.file.SaveAs(fileName);

            //var path = "";
            //if (File1 != null)
            //{
            //    if (File1.ContentLength > 0)
            //    {
            //        if (Path.GetExtension(File1.FileName).ToLower() == ".jpg"
            //            || Path.GetExtension(File1.FileName).ToLower() == ".png"
            //            || Path.GetExtension(File1.FileName).ToLower() == ".gif"
            //            || Path.GetExtension(File1.FileName).ToLower() == ".jpeg")
            //        {

            //            path = Path.Combine(Server.MapPath("~/Image/"), File1.FileName);
            //            File1.SaveAs(path);
            //            ViewBag.UploadSuccess = true;
            //        }
            //    }

            // pg.photo = "~/Image/";
            ////}


            if (ModelState.IsValid)
            {
                db.PGs.Add(pg);
                db.SaveChanges();
            }
            //ModelState.Clear();
            return RedirectToAction("Login", "Login");

        }



        public ActionResult RegClient()
        {
            return View();

        }

        [HttpPost]
        public ActionResult RegClient(Client cl)
        {


            if (ModelState.IsValid)
            {
                db.Clients.Add(cl);
                db.SaveChanges();
            }
            //ModelState.Clear();
            return RedirectToAction("Login", "Login");
          

        }


        //public ActionResult RegisterClient()
        //{
        //  //  ViewData["NamePG"] = Enum.GetValues(typeof(PG)).Cast<PG>().Select(c => new SelectListItem { Text = c.ToString(), Value = c.ToString() });
        //    //Client client = new Client();
        //    //var pg = db.PGs.ToList();

        //    //PhotographerClient pc = new PhotographerClient()
        //    //{
        //    //    Client = client,
        //    //    photographers = pg,
               

        //    //};

        //    //var pg = db.PGs.ToList();
        //    //PhotographerClient pc = new PhotographerClient
        //    //{
        //    //    photographers= pg
        //    //};



        //    //PG p = new PG();
        //    //ViewBag.Pg = new SelectList(db.PGs, "id", "User_Name").OrderBy(a=>a.Text);
        //    //var get = db.PGs.ToList();
        //    //List<SelectListItem> mySkills = new List<SelectListItem>(get, "id", "User_Name");





        //    //var get = db.PGs.ToList();
        //    //SelectList list = new SelectList(get, "id", "User_Name");
        //    //ViewBag.pg = list;

        //    return View();
        //}



        //[HttpPost]
        //public ActionResult RegisterClient(Client cl)
        //{

        //    //try
        //    //{
        //    //    if (ModelState.IsValid)
        //    //    {
        //    //        db.Clients.Add(cl.Client);
        //    //        db.SaveChanges();
        //    //    }
        //    //    return RedirectToAction("Login", "Login");
        //    //}
        //    //catch
        //    //{
        //    //    return View();
        //    //}


        //    if (ModelState.IsValid)
        //      {
        //          db.Clients.Add(cl);
        //          db.SaveChanges();
        //        }
        //       return RedirectToAction("Login", "Login");
        //}



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