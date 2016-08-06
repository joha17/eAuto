using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eAuto.Models
{
    public class Marca
    {
        [Required]
        public int IdMarca { get; set; }

        [Required]
        public string NombreMarca { get; set; }

        
        public int IdPais { get; set; }

        public Pais PaisMarca { get; set; }

        public enum Pais
        {
            Alemania, Francia
        }
    }
}