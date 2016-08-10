using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace eAuto.Models
{
    public class AutoNuevo
    {
        [Key]
        public int IdAutoNuevo { get; set; }

        public int IdMarca { get; set; }

        public int IdModelo { get; set; }

        public int IdUsuario { get; set; }

        public int IdAgencia { get; set; }

        public string Descripcion { get; set; }

        public string ImagenPath { get; set; }


        //Relaciones
        public virtual Marca Marca { get; set; }

        public virtual Modelo Modelo { get; set; }

        public virtual Agencia Agencia { get; set; }
    }
}