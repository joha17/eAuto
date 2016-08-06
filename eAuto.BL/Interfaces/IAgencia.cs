using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAuto.BL.Interfaces
{
    public interface IAgencia
    {
        List<DATOS.Agencia> ListarAgencia();
        DATOS.Agencia BuscarAgencia(int idagencia);
        void InsertarAgencia(DATOS.Agencia agencia);
        void ActualizarAgencia(DATOS.Agencia agencia);
        void EliminarAgencia(int idagencia);
    }
}
