using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eAuto.Models;

namespace eAuto.Controllers
{
    public class AgenciasController : Controller
    {
        private eAutoContext db = new eAutoContext();

        // GET: Agencias
        public ActionResult Index()
        {
            return View(db.Agencias.ToList());
        }

        // GET: Agencias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencia agencia = db.Agencias.Find(id);
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // GET: Agencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAgencia,NombreAgencia,Direccion,Tel,Administrador,Correo,Web")] Agencia agencia)
        {
            if (ModelState.IsValid)
            {
                db.Agencias.Add(agencia);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(agencia);
        }

        // GET: Agencias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencia agencia = db.Agencias.Find(id);
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // POST: Agencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAgencia,NombreAgencia,Direccion,Tel,Administrador,Correo,Web")] Agencia agencia)
        {
            if (ModelState.IsValid)
            {
                db.Entry(agencia).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(agencia);
        }

        // GET: Agencias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Agencia agencia = db.Agencias.Find(id);
            if (agencia == null)
            {
                return HttpNotFound();
            }
            return View(agencia);
        }

        // POST: Agencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Agencia agencia = db.Agencias.Find(id);
            db.Agencias.Remove(agencia);
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
