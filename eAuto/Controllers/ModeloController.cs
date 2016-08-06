using AutoMapper;
using eAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eAuto.Controllers
{
    public class ModeloController : Controller
    {
        // GET: Modelo
        public ActionResult Index()
        {
            BL.Interfaces.IModelo mod = new BL.Clases.Modelo();
            var listaModelos = mod.ListarModelos();
            var modelos = Mapper.Map<List<Models.Modelo>>(listaModelos);
            return View(modelos);
        }

        // GET: Modelo/Details/5
        public ActionResult Details(int id)
        {
            BL.Interfaces.IModelo mod = new BL.Clases.Modelo();
            var objetoModelo = mod.BuscarModelo(id);
            var modelo = Mapper.Map<Models.Modelo>(objetoModelo);
            return View(modelo);
        }

        // GET: Modelo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Modelo/Create
        [HttpPost]
        public ActionResult Create(Modelo modelo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                BL.Interfaces.IModelo mod = new BL.Clases.Modelo();
                var objetoModelo = Mapper.Map<DATOS.Modelo>(modelo);
                mod.InsertarModelo(objetoModelo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Modelo/Edit/5
        public ActionResult Edit(int id)
        {
            BL.Interfaces.IModelo mod = new BL.Clases.Modelo();
            var objetoModelo = mod.BuscarModelo(id);
            var modelo = Mapper.Map<Models.Modelo>(objetoModelo);
            return View(modelo);
        }

        // POST: Modelo/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Modelo modelo)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(modelo);
                }
                BL.Interfaces.IModelo mod = new BL.Clases.Modelo();
                var objetoModelo = Mapper.Map<DATOS.Modelo>(modelo);
                mod.ActualizarModelo(objetoModelo);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Modelo/Delete/5
        public ActionResult Delete(int id)
        {
            BL.Interfaces.IModelo mod = new BL.Clases.Modelo();
            mod.EliminarModelo(id);
            return RedirectToAction("Index");
        }

        // POST: Modelo/Delete/5
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
