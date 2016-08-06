using eAuto.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eAuto.DATOS;

namespace eAuto.BL.Clases
{
    public class Pais : IPais
    {
        public void ActualizarPais(DATOS.Pais pais)
        {
            DS.Interfaces.IPais paises = new DS.Clases.Pais();
            paises.ActualizarPais(pais);
        }

        public DATOS.Pais BuscarPais(int idpais)
        {
            DS.Interfaces.IPais paises = new DS.Clases.Pais();
            return paises.BuscarPais(idpais);
        }

        public void EliminarPais(int idpais)
        {
            DS.Interfaces.IPais paises = new DS.Clases.Pais();
            paises.EliminarPais(idpais);
        }

        public void InsertarPais(DATOS.Pais pais)
        {
            DS.Interfaces.IPais paises = new DS.Clases.Pais();
            paises.InsertarPais(pais);
        }

        public List<DATOS.Pais> ListarPaises()
        {
            DS.Interfaces.IPais pais = new DS.Clases.Pais();
            return pais.ListarPaises();
        }
    }
}
