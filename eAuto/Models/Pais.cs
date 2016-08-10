using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eAuto.Models
{
    public class Pais
    {
        [Key]
        public int IdPais { get; set; }
        public string NombrePais { get; set; }

        //Relaciones
        public virtual ICollection<Marca> Marcas { get; set; }
    }
}