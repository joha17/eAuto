using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eAuto.Models
{
    public class Modelo
    {
        [Key]
        public int IdModelo { get; set; }

        [Display(Name = "Modelo")]
        public string NombreModelo { get; set; }

        //Relaciones
        public virtual ICollection<AutoNuevo> AutosNuevos { get; set; }
        public virtual ICollection<AutoUsado> AutosUsados { get; set; }
    }
}