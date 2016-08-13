﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eAuto.Models
{
    public class Usuario
    {
        [Key]
        public int IdUsuario { get; set; }

        [Required(ErrorMessage = "Nombre es requerido")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Apellidos es requerido")]
        public string Apellidos { get; set; }

        [Phone]
        public string Telefono { get; set; }

        public string Direccion { get; set; }

        public bool Admin { get ; set; }

        [Required(ErrorMessage = "Correo electronico es requerido")]
        public string Correo { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Contraseña es requerido")]
        [DataType(DataType.Password)]
        public string Contrasena { get; set; }

        [Display(Name = "Confirme su Contraseña")]
        [Compare("Contrasena", ErrorMessage = "Confirm password doesn't match, Type again !")]
        [DataType(DataType.Password)]
        public string ConfirmeContrasena { get; set; }

        public Usuario()
        {
            Admin = false;
        } 
    }
}