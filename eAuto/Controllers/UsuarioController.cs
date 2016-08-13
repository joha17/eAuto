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
        public static string Llave = "jskruwiqhendmsud";

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
        public ActionResult Registro(Usuario usuario, string contrasena)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    usuario.Contrasena = Encriptar(contrasena, Llave);
                    db.Usuarios.Add(usuario);
                    db.SaveChanges();
                    //return RedirectToAction("Index");
                    ModelState.Clear();
                    ViewBag.Message = usuario.Nombre + " " + usuario.Apellidos + " te has registrado satisfactoriamente";
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

        public static string Decriptar(string contra, string llave)
        {
            byte[] keyArray = Encoding.UTF8.GetBytes(llave);
            byte[] encriptar = Convert.FromBase64String(contra);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateDecryptor();
            byte[] resultado = cTransform.TransformFinalBlock(encriptar, 0, encriptar.Length);
            return Encoding.UTF8.GetString(resultado);
        }

        public static string Encriptar(string contra, string llave)
        {
            byte[] keyArray = Encoding.UTF8.GetBytes(llave);
            byte[] encriptar = Encoding.UTF8.GetBytes(contra);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            ICryptoTransform cTransform = tdes.CreateEncryptor();
            byte[] resultado = cTransform.TransformFinalBlock(encriptar, 0, encriptar.Length);
            return Convert.ToBase64String(resultado, 0, resultado.Length);
        }
    }
}