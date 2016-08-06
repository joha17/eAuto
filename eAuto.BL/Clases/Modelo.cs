using eAuto.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eAuto.DATOS;

namespace eAuto.BL.Clases
{
    public class Modelo : IModelo
    {
        public void ActualizarModelo(DATOS.Modelo modelo)
        {
            DS.Interfaces.IModelo modelos = new DS.Clases.Modelo();
            modelos.ActualizarModelo(modelo);
        }

        public DATOS.Modelo BuscarModelo(int idmodelo)
        {

            DS.Interfaces.IModelo modelos = new DS.Clases.Modelo();
            return modelos.BuscarModelo(idmodelo);
        }

        public void EliminarModelo(int idmodelo)
        {
            DS.Interfaces.IModelo modelos = new DS.Clases.Modelo();
            modelos.EliminarModelo(idmodelo);
        }

        public void InsertarModelo(DATOS.Modelo modelo)
        {
            DS.Interfaces.IModelo modelos = new DS.Clases.Modelo();
            modelos.InsertarModelo(modelo);
        }

        public List<DATOS.Modelo> ListarModelos()
        {
            DS.Interfaces.IModelo modelos = new DS.Clases.Modelo();
            return modelos.ListarModelos();
        }
    }
}
