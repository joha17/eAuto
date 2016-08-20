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
using PagedList;

namespace eAuto.Controllers
{
    public class AutoNuevosController : Controller
    {
        private eAutoContext db = new eAutoContext();

        // GET: AutoNuevos
        public ActionResult Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.NameSortParm = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewBag.DateSortParm = sortOrder == "Date" ? "date_desc" : "Date";

            if (searchString != null)
            {
                page = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewBag.CurrentFilter = searchString;

            var autoNuevos = from s in db.AutoNuevos
                             select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                autoNuevos = autoNuevos.Where(s => s.Marca.NombreMarca.Contains(searchString)
                                       || s.Modelo.NombreModelo.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    autoNuevos = autoNuevos.OrderByDescending(s => s.Marca.NombreMarca);
                    break;
                case "Date":
                    autoNuevos = autoNuevos.OrderBy(s => s.Modelo.NombreModelo);
                    break;
                case "date_desc":
                    autoNuevos = autoNuevos.OrderByDescending(s => s.Modelo.NombreModelo);
                    break;
                default:  // Name ascending 
                    autoNuevos = autoNuevos.OrderBy(s => s.Marca.NombreMarca);
                    break;
            }

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(autoNuevos.ToPagedList(pageNumber, pageSize));
        }

        // GET: AutoNuevos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoNuevo autoNuevo = db.AutoNuevos.Find(id);
            if (autoNuevo == null)
            {
                return HttpNotFound();
            }
            return View(autoNuevo);
        }

        // GET: AutoNuevos/Create
        public ActionResult Create()
        {
            ViewBag.IdAgencia = new SelectList(db.Agencias, "IdAgencia", "NombreAgencia");
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "NombreMarca");
            ViewBag.IdModelo = new SelectList(db.Modelos, "IdModelo", "NombreModelo");
            return View();
        }

        // POST: AutoNuevos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAutoNuevo,IdMarca,IdModelo,IdUsuario,IdAgencia,Descripcion,ImagenPath")] AutoNuevo autoNuevo, HttpPostedFileBase FilePath)
        {
            if (ModelState.IsValid)
            {
                if (FilePath != null && FilePath.ContentLength > 0)
                {
                    var filename = Path.GetFileName(FilePath.FileName);
                    var path = Path.Combine(Server.MapPath("~/Imagenes/AutosNuevos"), filename);
                    autoNuevo.ImagenPath = filename;
                    FilePath.SaveAs(path);
                }
                db.AutoNuevos.Add(autoNuevo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdAgencia = new SelectList(db.Agencias, "IdAgencia", "NombreAgencia", autoNuevo.IdAgencia);
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "NombreMarca", autoNuevo.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modelos, "IdModelo", "NombreModelo", autoNuevo.IdModelo);
            return View(autoNuevo);
        }

        // GET: AutoNuevos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoNuevo autoNuevo = db.AutoNuevos.Find(id);
            if (autoNuevo == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdAgencia = new SelectList(db.Agencias, "IdAgencia", "NombreAgencia", autoNuevo.IdAgencia);
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "NombreMarca", autoNuevo.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modelos, "IdModelo", "NombreModelo", autoNuevo.IdModelo);
            return View(autoNuevo);
        }

        // POST: AutoNuevos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdAutoNuevo,IdMarca,IdModelo,IdUsuario,IdAgencia,Descripcion,ImagenPath")] AutoNuevo autoNuevo, HttpPostedFileBase FilePath)
        {
            if (ModelState.IsValid)
            {
                if (FilePath != null && FilePath.ContentLength > 0)
                {
                    var filename = Path.GetFileName(FilePath.FileName);
                    string ext = filename.Split(char.Parse(".")).LastOrDefault();
                    autoNuevo.ImagenPath = autoNuevo.IdAutoNuevo + "." + ext;
                    var path = Path.Combine(Server.MapPath("~/Imagenes/AutosNuevos"), autoNuevo.IdAutoNuevo + "." + ext);
                    FilePath.SaveAs(path);
                }
                db.Entry(autoNuevo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdAgencia = new SelectList(db.Agencias, "IdAgencia", "NombreAgencia", autoNuevo.IdAgencia);
            ViewBag.IdMarca = new SelectList(db.Marcas, "IdMarca", "NombreMarca", autoNuevo.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modelos, "IdModelo", "NombreModelo", autoNuevo.IdModelo);
            return View(autoNuevo);
        }

        // GET: AutoNuevos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoNuevo autoNuevo = db.AutoNuevos.Find(id);
            if (autoNuevo == null)
            {
                return HttpNotFound();
            }
            return View(autoNuevo);
        }

        // POST: AutoNuevos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AutoNuevo autoNuevo = db.AutoNuevos.Find(id);
            db.AutoNuevos.Remove(autoNuevo);
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
