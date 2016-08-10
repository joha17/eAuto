using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eAuto.Models;
using System.IO;

namespace eAuto.Controllers
{
    public class AutoUsadosController : Controller
    {
        private eAutoContext db = new eAutoContext();

        // GET: AutoUsados
        public ActionResult Index()
        {
            var autoUsadoes = db.AutoUsadoes.Include(a => a.Color).Include(a => a.EstadoAuto).Include(a => a.Marca).Include(a => a.Modelo);
            return View(autoUsadoes.ToList());
        }

        // GET: AutoUsados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoUsado autoUsado = db.AutoUsadoes.Find(id);
            if (autoUsado == null)
            {
                return HttpNotFound();
            }
            return View(autoUsado);
        }

        // GET: AutoUsados/Create
        public ActionResult Create()
        {
            ViewBag.IdColor = new SelectList(db.Colors, "IdColor", "NombreColor");
            ViewBag.IdEstadoAuto = new SelectList(db.EstadoAutoes, "IdEstadoAuto", "NombreEstado");
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "NombreMarca");
            ViewBag.IdModelo = new SelectList(db.Modeloes, "IdModelo", "NombreModelo");
            return View();
        }

        // POST: AutoUsados/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost,ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAutoUsado,IdMarca,IdModelo,IdUsuario,IdEstadoAuto,IdColor,Precio,Descripcion,Km,ImagenPath")] AutoUsado autoUsado, HttpPostedFileBase FilePath)
        {
            if (ModelState.IsValid)
            {
                if (FilePath != null && FilePath.ContentLength > 0)
                {
                    var filename = Path.GetFileName(FilePath.FileName);
                    string ext = filename.Split(char.Parse(".")).LastOrDefault();
                    autoUsado.ImagenPath = autoUsado.IdAutoUsado + "." + ext;
                    var path = Path.Combine(Server.MapPath("~/Imagenes/AutosUsados"), autoUsado.IdAutoUsado + "." + ext);
                    FilePath.SaveAs(path);
                }
                db.AutoUsadoes.Add(autoUsado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdColor = new SelectList(db.Colors, "IdColor", "NombreColor", autoUsado.IdColor);
            ViewBag.IdEstadoAuto = new SelectList(db.EstadoAutoes, "IdEstadoAuto", "NombreEstado", autoUsado.IdEstadoAuto);
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "NombreMarca", autoUsado.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modeloes, "IdModelo", "NombreModelo", autoUsado.IdModelo);
            return View(autoUsado);
        }

        // GET: AutoUsados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoUsado autoUsado = db.AutoUsadoes.Find(id);
            if (autoUsado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdColor = new SelectList(db.Colors, "IdColor", "NombreColor", autoUsado.IdColor);
            ViewBag.IdEstadoAuto = new SelectList(db.EstadoAutoes, "IdEstadoAuto", "NombreEstado", autoUsado.IdEstadoAuto);
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "NombreMarca", autoUsado.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modeloes, "IdModelo", "NombreModelo", autoUsado.IdModelo);
            return View(autoUsado);
        }

        // POST: AutoUsados/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAutoUsado,IdMarca,IdModelo,IdUsuario,IdEstadoAuto,IdColor,Precio,Descripcion,Km,ImagenPath")] AutoUsado autoUsado)
        {
            if (ModelState.IsValid)
            {
                db.Entry(autoUsado).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdColor = new SelectList(db.Colors, "IdColor", "NombreColor", autoUsado.IdColor);
            ViewBag.IdEstadoAuto = new SelectList(db.EstadoAutoes, "IdEstadoAuto", "NombreEstado", autoUsado.IdEstadoAuto);
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "NombreMarca", autoUsado.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modeloes, "IdModelo", "NombreModelo", autoUsado.IdModelo);
            return View(autoUsado);
        }

        // GET: AutoUsados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoUsado autoUsado = db.AutoUsadoes.Find(id);
            if (autoUsado == null)
            {
                return HttpNotFound();
            }
            return View(autoUsado);
        }

        // POST: AutoUsados/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutoUsado autoUsado = db.AutoUsadoes.Find(id);
            db.AutoUsadoes.Remove(autoUsado);
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
