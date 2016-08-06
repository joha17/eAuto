using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eAuto.BL.Interfaces;
using eAuto.DATOS;

namespace eAuto.BL.Clases
{
    public class Marca : IMarca
    {
        public void ActualizarMarca(DATOS.Marca marca)
        {
            DS.Interfaces.IMarca marcas = new DS.Clases.Marca();
            marcas.ActualizarMarca(marca);
        }

        public DATOS.Marca BuscarMarca(int idmarca)
        {
            DS.Interfaces.IMarca marca = new DS.Clases.Marca();
            return marca.BuscarMarca(idmarca);
        }

        public void EliminarMarca(int idmarca)
        {
            DS.Interfaces.IMarca marcas = new DS.Clases.Marca();
            marcas.EliminarMarca(idmarca);
        }

        public void InsertarMarca(DATOS.Marca marca)
        {
            DS.Interfaces.IMarca marcas = new DS.Clases.Marca();
            marcas.InsertarMarca(marca);
        }

        public List<DATOS.Marca> ListarMarcas()
        {
            DS.Interfaces.IMarca marca = new DS.Clases.Marca();
            return marca.ListarMarcas();
        }
    }
}
