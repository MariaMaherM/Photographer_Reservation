using PG_Project.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PG_Project.Controllers;

namespace PG_Project.Controllers
{
    public class LoginController : Controller
    {

        ProjectContext db = new ProjectContext();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }




     



        public ActionResult Login()
        {


            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Admin adm, PG pg , Client tm)
        {
            if (ModelState.IsValid)
            {
                var details = (from userlist in db.Admins
                               where userlist.User_Name == adm.User_Name && userlist.Password == adm.Password
                               select new
                               {
                                  
                                   userlist.Email,
                                   userlist.id,
                                   userlist.User_Name
                               }).ToList();


                var photographer = (from userlist in db.PGs
                                 where userlist.User_Name == pg.User_Name && userlist.User_Name == pg.Password
                                 select new
                                 {
                                    
                                     userlist.Email,
                                     userlist.id,
                                     userlist.User_Name
                                 }).ToList();


                var client = (from userlist in db.Clients
                                  where userlist.User_Name == tm.User_Name && userlist.User_Name == tm.Password
                                  select new
                                  {
                                      userlist.Phone_Number,
                                      userlist.Email,
                                      userlist.id,
                                      userlist.User_Name
                                  }).ToList();


                if (details.FirstOrDefault() != null)
                {
                    Session["id"] = details.FirstOrDefault().id;
                    Session["User_Name"] = details.FirstOrDefault().User_Name;
                    return RedirectToAction("WelcomeAdmin","Login");

                }
                if (photographer.FirstOrDefault() != null)
                {
                    Session["id"] = photographer.FirstOrDefault().id;
                    Session["User_Name"] = photographer.FirstOrDefault().User_Name;
                    return RedirectToAction("WelcomePG","Login");
                }
                if (client.FirstOrDefault() != null)
                {
                    Session["id"] = client.FirstOrDefault().id;
                    Session["User_Name"] = client.FirstOrDefault().User_Name;
                    return RedirectToAction("WelcomeClient","Login");

                }
            }





            else
            {
                ModelState.AddModelError("", "Invalid Data");
            }

            return View(adm);

        }

        public ActionResult WelcomeAdmin()
        {

            return View();
        }
        public ActionResult WelcomePG()
        {

            return View();
        }
        public ActionResult WelcomeClient()
        {

            return View();
        }



















        // GET: Login/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Login/Create
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

        // GET: Login/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Login/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Login/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
