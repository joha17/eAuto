using System;
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

        [Required]
        public string Nombre { get; set; }

        [Required]
        public string PrApellido { get; set; }

        [Required]
        public string SegApellido { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Contrasena { get; set; }
    }
}