using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace eAuto.Models
{
    public class AutoUsado
    {
        [Key]
        public int IdAutoUsado  { get; set; }
        
        public int IdMarca { get; set; }

        public int IdModelo { get; set; }

        public int IdUsuario { get; set; }

        public int IdEstadoAuto { get; set; }

        public int IdColor { get; set; }

        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public decimal Precio { get; set; }

        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }

        [Display(Name = "Kilometraje")]
        public string Km { get; set; }

        public string ImagenPath { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreacion { get { return DateTime.Now; } }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime FechaVigencia { get { return FechaCreacion.AddMonths(3);} }

        //Relaciones
        public virtual Marca Marca { get; set; }

        public virtual Modelo Modelo { get; set; }

        public virtual EstadoAuto EstadoAuto { get; set; }

        public virtual Color Color { get; set; }

        public virtual Usuario Usuario { get; set; }
        
    }
}