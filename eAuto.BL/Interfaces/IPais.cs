using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAuto.BL.Interfaces
{
    public interface IPais
    {
        List<DATOS.Pais> ListarPaises();
        DATOS.Pais BuscarPais(int idpais);
        void InsertarPais(DATOS.Pais pais);
        void ActualizarPais(DATOS.Pais pais);
        void EliminarPais(int idpais);
    }
}
