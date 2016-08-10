using AutoMapper;
using eAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eAuto.Controllers
{
    public class PaisController : Controller
    {
        // GET: Pais
        public ActionResult Index()
        {
            BL.Interfaces.IPais pai = new BL.Clases.Pais();
            var listaPaises = pai.ListarPaises();
            var paises = Mapper.Map<List<Models.Pais>>(listaPaises);
            return View(paises);
        }

        // GET: Pais/Details/5
        public ActionResult Details(int id)
        {
            BL.Interfaces.IPais pai = new BL.Clases.Pais();
            var objetoPais = pai.BuscarPais(id);
            var pais = Mapper.Map<Models.Pais>(objetoPais);
            return View(pais);
        }

        // GET: Pais/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pais/Create
        [HttpPost]
        public ActionResult Create(Pais pais)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            BL.Interfaces.IPais pai = new BL.Clases.Pais();
            var objetoPais = Mapper.Map<DATOS.Pais>(pais);
            pai.InsertarPais(objetoPais);
            return RedirectToAction("Index");
        }

        // GET: Pais/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                BL.Interfaces.IPais pai = new BL.Clases.Pais();
                var objetoPais = pai.BuscarPais(id);
                var pais = Mapper.Map<Models.Pais>(objetoPais);
                return View(pais);
            }
            catch 
            {

                return RedirectToAction("~/Views/Shared/Error");
            }
           
        }

        // POST: Pais/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Pais pais)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                BL.Interfaces.IPais pai = new BL.Clases.Pais();
                var objetoPais = Mapper.Map<DATOS.Pais>(pais);
                pai.ActualizarPais(objetoPais);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pais/Delete/5
        public ActionResult Delete(int id)
        {
            BL.Interfaces.IPais pai = new BL.Clases.Pais();
            pai.EliminarPais(id);
            return RedirectToAction("Index");
        }

        // POST: Pais/Delete/5
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
