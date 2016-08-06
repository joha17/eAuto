using AutoMapper;
using eAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eAuto.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario
        public ActionResult Index()
        {
            BL.Interfaces.IUsuario usu = new BL.Clases.Usuario();
            var listaUsuarios = usu.ListarUsuario();
            var usuarios = Mapper.Map<List<Models.Usuario>>(listaUsuarios);
            return View(usuarios);
        }

        // GET: Usuario/Details/5
        public ActionResult Details(int id)
        {
            BL.Interfaces.IUsuario usu = new BL.Clases.Usuario();
            var objetoUsuario = usu.BuscarUsuario(id);
            var usuario = Mapper.Map<Models.Usuario>(objetoUsuario);
            return View(usuario);
        }

        // GET: Usuario/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        [HttpPost]
        public ActionResult Create(Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View();
                }
                BL.Interfaces.IUsuario usu = new BL.Clases.Usuario();
                var objetoUsuario = Mapper.Map<DATOS.Usuario>(usuario);
                usu.InsertarUsuario(objetoUsuario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Edit/5
        public ActionResult Edit(int id)
        {
            BL.Interfaces.IUsuario usu = new BL.Clases.Usuario();
            var objetoUsuario = usu.BuscarUsuario(id);
            var usuario = Mapper.Map<Models.Usuario>(objetoUsuario);
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Usuario usuario)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(usuario);
                }
                BL.Interfaces.IUsuario usu = new BL.Clases.Usuario();
                var objetoUsuario = Mapper.Map<DATOS.Usuario>(usuario);
                usu.ActualizarUsuario(objetoUsuario);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Usuario/Delete/5
        public ActionResult Delete(int id)
        {
            BL.Interfaces.IUsuario usu = new BL.Clases.Usuario();
            usu.EliminarUsuario(id);
            return RedirectToAction("Index");
        }

        // POST: Usuario/Delete/5
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
