using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eAuto.Models
{
    public class Color
    {
        [Key]
        public int IdColor { get; set; }

        [Display(Name = "Color")]
        public string NombreColor { get; set; }

        //Relaciones
        public virtual ICollection<AutoUsado> AutosUsados { get; set; }
    }
}