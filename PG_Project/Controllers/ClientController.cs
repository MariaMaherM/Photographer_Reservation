using PG_Project.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PG_Project.Controllers;

namespace PG_Project.Controllers
{
    public class ClientController : Controller
    {
        ProjectContext db = new ProjectContext();
        LoginController log = new LoginController();

        // GET: Client
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult ClientProfile()
        {
            return View(db.Clients.ToList());
        }


        // GET: Client/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Client/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Client/Create
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
        
        // GET: Client/Edit/5
        public ActionResult Edit(int id )
        {

            Client cl = db.Clients.Find(id);
            if (cl == null)
            {
                return HttpNotFound();
            }
            return View(cl);

            //return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Client cl)
        {
            
                if (ModelState.IsValid)
                {
                    db.Entry(cl).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("WelcomeClient", "Login");
           
        }

        // GET: Client/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Client/Delete/5
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
