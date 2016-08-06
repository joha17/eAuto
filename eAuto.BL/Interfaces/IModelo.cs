using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAuto.BL.Interfaces
{
    public interface IModelo
    {
        List<DATOS.Modelo> ListarModelos();
        DATOS.Modelo BuscarModelo(int idmodelo);
        void InsertarModelo(DATOS.Modelo modelo);
        void ActualizarModelo(DATOS.Modelo modelo);
        void EliminarModelo(int idmodelo);
    }
}
