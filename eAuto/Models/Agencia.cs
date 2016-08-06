using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eAuto.Models
{
    public class Agencia
    {
        [Required]
        public int IdAgencia { get; set; }

        [Required]
        public string NombreAgencia { get; set; }

        [Required]
        public string Telefono { get; set; }
        
        public string Email { get; set; }

        public string Web { get; set; }
    }
}