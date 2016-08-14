using eAuto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
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
                        //return RedirectToAction("Index");
                        ModelState.Clear();
                        ViewBag.Message = usuario.Nombre + " " + usuario.Apellidos + " te has registrado satisfactoriamente";
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

        public ActionResult CerrarSesion()
        {
            FormsAuthentication.SignOut();
            Session.Abandon(); // it will clear the session at the end of request
            return RedirectToAction("Index", "AutoUsados");
        }
    }
}