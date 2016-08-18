using eAuto.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace eAuto.Controllers
{
    public class UsuarioController : Controller
    {
        private eAutoContext db = new eAutoContext();
        
        // GET: Usuario
        public ActionResult Index()
        {

            return View(db.Usuarios.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        public ActionResult VerPerfil()
        {
            
            return View();
        }

        public ActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Registro([Bind(Include = "IdUsuario,Nombre,Apellidos,Telefono,Direccion,Admin,Correo,Contrasena,ConfirmeContrasena")]Usuario usuario, string contrasena)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        db.Usuarios.Add(usuario);
                        db.SaveChanges();
                        return RedirectToAction("Login");
                        //ViewBag.Message = usuario.Nombre + " " + usuario.Apellidos + " te has registrado satisfactoriamente";
                    }
                    
                }
                catch (Exception ex)
                {
                    return View(ex);
                }
                
            }
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(Usuario usuario)
        {
            var usr = db.Usuarios.Where(u => u.Correo == usuario.Correo && u.Contrasena == usuario.Contrasena).FirstOrDefault();
            if (usr != null)
            {
                Session["IdUsuario"] = usr.IdUsuario.ToString();
                Session["Correo"] = usr.Correo.ToString();
                Session["Nombre"] = usr.Nombre.ToString();
                Session["Apellidos"] = usr.Apellidos.ToString();
                Session["Direccion"] = usr.Direccion.ToString();
                Session["Telefono"] = usr.Telefono.ToString();
                Session["Admin"] = usr.Admin;
                return RedirectToAction("LoggedIn");
            }
            else
            {
                ModelState.AddModelError("", "Correo o contrasena invalidos");
            }
            return View();
        }

        public ActionResult LoggedIn()
        {
            if (Session["IdUsuario"] != null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

        // GET: Paises/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Paises/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IdUsuario,Nombre,Apellidos,Telefono,Direccion,Admin,Correo,Contrasena,ConfirmeContrasena")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("VerPerfil");
            }
            return View(usuario);
        }

        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "AutoUsados");
        }
    }
}