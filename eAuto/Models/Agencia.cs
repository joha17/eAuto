using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eAuto.Models
{
    public class Agencia
    {
        [Key]
        public int IdAgencia { get; set; }

        [Display(Name = "Nombre de Agencia")]
        [Required(ErrorMessage = "El atributo {0} es obligatario")]
        public string NombreAgencia { get; set; }

        [Required(ErrorMessage = "El atributo {0} es obligatario")]
        public string Direccion { get; set; }

        [Display(Name = "Telefono")]
        [Required(ErrorMessage = "El atributo {0} es obligatario")]
        public string Tel { get; set; }

        
        public string Administrador { get; set; }

        [DataType(DataType.EmailAddress)]
        [Display(Name = "Correo electronico")]
        [Required(ErrorMessage = "El atributo {0} es obligatario")]
        public string Correo { get; set; }

        [DataType(DataType.Url)]
        [Display(Name = "Sitio web")]
        public string Web { get; set; }

        //Relaciones
        public virtual ICollection<AutoNuevo> AutosNuevos { get; set; }
    }
}