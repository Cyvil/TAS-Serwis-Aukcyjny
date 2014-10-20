using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Proba.Models;

namespace Proba.Controllers
{
    public class PrzedmiotyController : Controller
    {
        private PrzedmiotyDBContext db = new PrzedmiotyDBContext();

        // GET: /Przedmioty/
        public ActionResult Index()
        {
            return View(db.Przedmioty.ToList());
        }

        // GET: /Przedmioty/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przedmioty przedmioty = db.Przedmioty.Find(id);
            if (przedmioty == null)
            {
                return HttpNotFound();
            }
            return View(przedmioty);
        }

        // GET: /Przedmioty/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Przedmioty/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="ID,Nazwa,Kategoria,Cena,DataZakonczenia,Wystawiajacy")] Przedmioty przedmioty)
        {
            if (ModelState.IsValid)
            {
                db.Przedmioty.Add(przedmioty);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(przedmioty);
        }

        // GET: /Przedmioty/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przedmioty przedmioty = db.Przedmioty.Find(id);
            if (przedmioty == null)
            {
                return HttpNotFound();
            }
            return View(przedmioty);
        }

        // POST: /Przedmioty/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="ID,Nazwa,Kategoria,Cena,DataZakonczenia,Wystawiajacy")] Przedmioty przedmioty)
        {
            if (ModelState.IsValid)
            {
                db.Entry(przedmioty).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(przedmioty);
        }

        // GET: /Przedmioty/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Przedmioty przedmioty = db.Przedmioty.Find(id);
            if (przedmioty == null)
            {
                return HttpNotFound();
            }
            return View(przedmioty);
        }

        // POST: /Przedmioty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Przedmioty przedmioty = db.Przedmioty.Find(id);
            db.Przedmioty.Remove(przedmioty);
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
    }
}
