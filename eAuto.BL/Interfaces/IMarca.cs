using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAuto.BL.Interfaces
{
    public interface IMarca
    {
        List<DATOS.Marca> ListarMarcas();
        DATOS.Marca BuscarMarca(int idmarca);
        void InsertarMarca(DATOS.Marca marca);
        void ActualizarMarca(DATOS.Marca marca);
        void EliminarMarca(int idmarca);
    }
}
