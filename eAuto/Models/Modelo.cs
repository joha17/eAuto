using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eAuto.Models
{
    public class Modelo
    {
        [Required]
        public int IdModelo { get; set; }

        [Required]
        public string NombreModelo { get; set; }
    }
}