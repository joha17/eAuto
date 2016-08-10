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
    public class EstadoAutosController : Controller
    {
        private eAutoContext db = new eAutoContext();

        // GET: EstadoAutos
        public ActionResult Index()
        {
            return View(db.EstadoAutoes.ToList());
        }

        // GET: EstadoAutos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoAuto estadoAuto = db.EstadoAutoes.Find(id);
            if (estadoAuto == null)
            {
                return HttpNotFound();
            }
            return View(estadoAuto);
        }

        // GET: EstadoAutos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EstadoAutos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdEstadoAuto,NombreEstado")] EstadoAuto estadoAuto)
        {
            if (ModelState.IsValid)
            {
                db.EstadoAutoes.Add(estadoAuto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(estadoAuto);
        }

        // GET: EstadoAutos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoAuto estadoAuto = db.EstadoAutoes.Find(id);
            if (estadoAuto == null)
            {
                return HttpNotFound();
            }
            return View(estadoAuto);
        }

        // POST: EstadoAutos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdEstadoAuto,NombreEstado")] EstadoAuto estadoAuto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(estadoAuto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(estadoAuto);
        }

        // GET: EstadoAutos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EstadoAuto estadoAuto = db.EstadoAutoes.Find(id);
            if (estadoAuto == null)
            {
                return HttpNotFound();
            }
            return View(estadoAuto);
        }

        // POST: EstadoAutos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EstadoAuto estadoAuto = db.EstadoAutoes.Find(id);
            db.EstadoAutoes.Remove(estadoAuto);
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
