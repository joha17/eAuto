using AutoMapper;
using eAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eAuto.Controllers
{
    public class AgenciaController : Controller
    {
        // GET: Agencia
        public ActionResult Index()
        {
            BL.Interfaces.IAgencia age = new BL.Clases.Agencia();
            var listaAgencia = age.ListarAgencia();
            var agencia = Mapper.Map<List<Models.Agencia>>(listaAgencia);
            return View(agencia);
        }

        // GET: Agencia/Details/5
        public ActionResult Details(int id)
        {
            BL.Interfaces.IAgencia age = new BL.Clases.Agencia();
            var objetoAgencia = age.BuscarAgencia(id);
            var agencia = Mapper.Map<Models.Agencia>(objetoAgencia);
            return View(agencia);
        }

        // GET: Agencia/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Agencia/Create
        [HttpPost]
        public ActionResult Create(Agencia agencia)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                BL.Interfaces.IAgencia age = new BL.Clases.Agencia();
                var objetoAgencia = Mapper.Map<DATOS.Agencia>(agencia);
                age.InsertarAgencia(objetoAgencia);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Agencia/Edit/5
        public ActionResult Edit(int id)
        {
            BL.Interfaces.IAgencia age = new BL.Clases.Agencia();
            var objetoAgencia = age.BuscarAgencia(id);
            var agencia = Mapper.Map<Models.Agencia>(objetoAgencia);
            return View(agencia);
        }

        // POST: Agencia/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Agencia agencia)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                BL.Interfaces.IAgencia age = new BL.Clases.Agencia();
                var objetoAgencia = Mapper.Map<DATOS.Agencia>(agencia);
                age.ActualizarAgencia(objetoAgencia);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Agencia/Delete/5
        public ActionResult Delete(int id)
        {
            BL.Interfaces.IAgencia agencia = new BL.Clases.Agencia();
            agencia.EliminarAgencia(id);
            return RedirectToAction("Index");
        }

        // POST: Agencia/Delete/5
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
