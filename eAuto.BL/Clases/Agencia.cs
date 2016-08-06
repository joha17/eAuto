using eAuto.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eAuto.DATOS;

namespace eAuto.BL.Clases
{
    public class Agencia : IAgencia
    {
        public void ActualizarAgencia(DATOS.Agencia agencia)
        {
            DS.Interfaces.IAgencia agencias = new DS.Clases.Agencia();
            agencias.ActualizarAgencia(agencia);
        }

        public DATOS.Agencia BuscarAgencia(int idagencia)
        {
            DS.Interfaces.IAgencia agencia = new DS.Clases.Agencia();
            return agencia.BuscarAgencia(idagencia);
        }

        public void EliminarAgencia(int idagencia)
        {
            DS.Interfaces.IAgencia agencias = new DS.Clases.Agencia();
            agencias.EliminarAgencia(idagencia);
        }

        public void InsertarAgencia(DATOS.Agencia agencia)
        {
            DS.Interfaces.IAgencia agencias = new DS.Clases.Agencia();
            agencias.InsertarAgencia(agencia);
        }

        public List<DATOS.Agencia> ListarAgencia()
        {
            DS.Interfaces.IAgencia agencia = new DS.Clases.Agencia();
            return agencia.ListarAgencia();
        }
    }
}
