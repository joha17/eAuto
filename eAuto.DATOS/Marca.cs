using ServiceStack.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAuto.DATOS
{
    public class Marca
    {

        public int IdMarca { get; set; }
        public string NombreMarca { get; set; }
        public string NombrePais { get; set; }
    }
}
