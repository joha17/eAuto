using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using eAuto.Models;
using System.IO;
using System;
using PagedList;

namespace eAuto.Controllers
{
    public class AutoUsadosController : Controller
    {
        private eAutoContext db = new eAutoContext();

        // GET: AutoUsados
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

            var autoUsados = from s in db.AutoUsados
                           select s;
            if (!String.IsNullOrEmpty(searchString))
            {
                autoUsados = autoUsados.Where(s => s.Marca.NombreMarca.Contains(searchString)
                                       || s.Modelo.NombreModelo.Contains(searchString));
            }
            switch (sortOrder)
            {
                case "name_desc":
                    autoUsados = autoUsados.OrderByDescending(s => s.Marca.NombreMarca);
                    break;
                case "Date":
                    autoUsados = autoUsados.OrderBy(s => s.FechaCreacion);
                    break;
                case "date_desc":
                    autoUsados = autoUsados.OrderByDescending(s => s.FechaCreacion);
                    break;
                default:  // Name ascending 
                    autoUsados = autoUsados.OrderBy(s => s.Marca.NombreMarca);
                    break;
            }

            int pageSize = 12;
            int pageNumber = (page ?? 1);
            return View(autoUsados.ToPagedList(pageNumber, pageSize));

        }

        // GET: AutoUsados/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoUsado autoUsado = db.AutoUsados.Find(id);
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
            ViewBag.IdEstadoAuto = new SelectList(db.EstadoAutos, "IdEstadoAuto", "NombreEstado");
            ViewBag.IdMarca = new SelectList(db.Marcas.OrderBy(x => x.NombreMarca), "IdMarca", "NombreMarca");
            ViewBag.IdModelo = new SelectList(db.Modelos.OrderBy(x => x.NombreModelo), "IdModelo", "NombreModelo");
            //ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre");
            return View();
        }

        // POST: AutoUsados/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IdAutoUsado,IdMarca,IdModelo,IdUsuario,IdEstadoAuto,IdColor,Precio,Descripcion,Km,ImagenPath")] AutoUsado autoUsado, HttpPostedFileBase FilePath)
        {
            if (ModelState.IsValid)
            {
                if (FilePath != null && FilePath.ContentLength > 0)
                {
                    var filename = Path.GetFileName(FilePath.FileName);
                    var path = Path.Combine(Server.MapPath("~/Imagenes/AutosUsados"), filename);
                    autoUsado.ImagenPath = filename;
                    FilePath.SaveAs(path);
                }
                db.AutoUsados.Add(autoUsado);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdColor = new SelectList(db.Colors, "IdColor", "NombreColor", autoUsado.IdColor);
            ViewBag.IdEstadoAuto = new SelectList(db.EstadoAutos, "IdEstadoAuto", "NombreEstado", autoUsado.IdEstadoAuto);
            ViewBag.IdMarca = new SelectList(db.Marcas.OrderBy(x => x.NombreMarca), "IdMarca", "NombreMarca", autoUsado.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modelos.OrderBy(x => x.NombreModelo), "IdModelo", "NombreModelo", autoUsado.IdModelo);
            //ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", autoUsado.IdUsuario);
            return View(autoUsado);
        }

        // GET: AutoUsados/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoUsado autoUsado = db.AutoUsados.Find(id);
            if (autoUsado == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdColor = new SelectList(db.Colors, "IdColor", "NombreColor", autoUsado.IdColor);
            ViewBag.IdEstadoAuto = new SelectList(db.EstadoAutos, "IdEstadoAuto", "NombreEstado", autoUsado.IdEstadoAuto);
            ViewBag.IdMarca = new SelectList(db.Marcas.OrderBy(x => x.NombreMarca), "IdMarca", "NombreMarca", autoUsado.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modelos.OrderBy(x => x.NombreModelo), "IdModelo", "NombreModelo", autoUsado.IdModelo);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", autoUsado.IdUsuario);
            return View(autoUsado);
        }

        // POST: AutoUsados/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            ViewBag.IdEstadoAuto = new SelectList(db.EstadoAutos, "IdEstadoAuto", "NombreEstado", autoUsado.IdEstadoAuto);
            ViewBag.IdMarca = new SelectList(db.Marcas.OrderBy(x => x.NombreMarca), "IdMarca", "NombreMarca", autoUsado.IdMarca);
            ViewBag.IdModelo = new SelectList(db.Modelos.OrderBy(x => x.NombreModelo), "IdModelo", "NombreModelo", autoUsado.IdModelo);
            ViewBag.IdUsuario = new SelectList(db.Usuarios, "IdUsuario", "Nombre", autoUsado.IdUsuario);
            return View(autoUsado);
        }

        // GET: AutoUsados/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AutoUsado autoUsado = db.AutoUsados.Find(id);
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
            AutoUsado autoUsado = db.AutoUsados.Find(id);
            db.AutoUsados.Remove(autoUsado);
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
