using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eAuto.Models
{
    public class EstadoAuto
    {
        [Key]
        public int IdEstadoAuto { get; set; }

        public string NombreEstado { get; set; }

        //Relaciones
        public virtual ICollection<AutoUsado> AutosUsados { get; set; }
    }
}