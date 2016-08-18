using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eAuto.Models
{
    public class Marca
    {
        [Key]
        public int IdMarca { get; set; }

        [Display(Name = "Marca")]
        public string NombreMarca { get; set; }

        [Display(Name = "Pais Origen")]
        public int IdPais { get; set; }
        
        //Relaciones
        public virtual ICollection<AutoNuevo> AutosNuevos { get; set; }
        public virtual ICollection<AutoUsado> AutosUsados { get; set; }
        public virtual ICollection<Modelo> Modelos { get; set; }
        public virtual Pais Pais { get; set; }
    }
}