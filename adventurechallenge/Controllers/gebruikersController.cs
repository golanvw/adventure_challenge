using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using adventurechallenge.Models;

namespace adventurechallenge.Controllers
{
    public class gebruikersController : Controller
    {
        private mijncontext db = new mijncontext();

        // GET: gebruikers
        public ActionResult Index()
        {
            return View(db.gebruiker.ToList());
        }

        // GET: gebruikers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gebruiker gebruiker = db.gebruiker.Find(id);
            if (gebruiker == null)
            {
                return HttpNotFound();
            }
            return View(gebruiker);
        }

        // GET: gebruikers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: gebruikers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "GebruikerId,GebruikerNaam,ChallengesVoltooid")] gebruiker gebruiker)
        {
            if (ModelState.IsValid)
            {
                db.gebruiker.Add(gebruiker);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gebruiker);
        }

        // GET: gebruikers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gebruiker gebruiker = db.gebruiker.Find(id);
            if (gebruiker == null)
            {
                return HttpNotFound();
            }
            return View(gebruiker);
        }

        // POST: gebruikers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "GebruikerId,GebruikerNaam,ChallengesVoltooid")] gebruiker gebruiker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gebruiker).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gebruiker);
        }

        // GET: gebruikers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            gebruiker gebruiker = db.gebruiker.Find(id);
            if (gebruiker == null)
            {
                return HttpNotFound();
            }
            return View(gebruiker);
        }

        // POST: gebruikers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            gebruiker gebruiker = db.gebruiker.Find(id);
            db.gebruiker.Remove(gebruiker);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        adventure_challengeEntities entity = new adventure_challengeEntities();
        public ActionResult login()
        {
            return View();
        }
        public ActionResult signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult login(loginmodelview credentials)
        {
            bool userexist = entity.gebruiker.Any(x => x.GebruikerNaam == credentials.gebruikernaam && x.Wachtwoord == credentials.Wachtwoord);
            gebruiker u = entity.gebruiker.FirstOrDefault(x => x.GebruikerNaam == credentials.gebruikernaam && x.Wachtwoord == credentials.Wachtwoord);
            if(userexist)
            {
                FormsAuthentication.SetAuthCookie(u.GebruikerNaam, false);
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError("", "gebruikersnaam of wachtwoord is fout");
            return View();
        }
        [HttpPost]
        public ActionResult signup(gebruiker gebruikerinfo)
        {
            entity.gebruiker.Add(gebruikerinfo);
            entity.SaveChanges();
            return RedirectToAction("login");
        }
        public ActionResult signout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }
    }
}
