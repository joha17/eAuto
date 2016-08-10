using AutoMapper;
using eAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eAuto.Controllers
{
    public class MarcaController : Controller
    {


        // GET: Marca
        public ActionResult Index()
        {
            BL.Interfaces.IMarca mar = new BL.Clases.Marca();
            var listaMarcas = mar.ListarMarcas();
            var marcas = Mapper.Map<List<Models.Marca>>(listaMarcas);
            return View(marcas);
        }

        // GET: Marca/Details/5
        public ActionResult Details(int id)
        {
            BL.Interfaces.IMarca mar = new BL.Clases.Marca();
            var objetoMarca = mar.BuscarMarca(id);
            var marca = Mapper.Map<Models.Marca>(objetoMarca);
            return View(marca);
        }

        // GET: Marca/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Marca/Create
        [HttpPost]
        public ActionResult Create(Marca marca)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            BL.Interfaces.IMarca mar = new BL.Clases.Marca();
            var objetoMarca = Mapper.Map<DATOS.Marca>(marca);
            mar.InsertarMarca(objetoMarca);
            return RedirectToAction("Index");
        }

        // GET: Marca/Edit/5
        public ActionResult Edit(int id)
        {
            BL.Interfaces.IMarca mar = new BL.Clases.Marca();
            var objetoMarca = mar.BuscarMarca(id);
            var marca = Mapper.Map<Models.Marca>(objetoMarca);
            return View(marca);
        }

        // POST: Marca/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Marca marca)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(marca);
                }
                BL.Interfaces.IMarca mar = new BL.Clases.Marca();
                var objetoMarca = Mapper.Map<DATOS.Marca>(marca);
                mar.ActualizarMarca(objetoMarca);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Marca/Delete/5
        public ActionResult Delete(int id)
        {
            BL.Interfaces.IMarca mar = new BL.Clases.Marca();
            mar.EliminarMarca(id);
            return RedirectToAction("Index");
        }

    }
}
