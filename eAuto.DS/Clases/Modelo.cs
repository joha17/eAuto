using eAuto.DS.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eAuto.DATOS;
using ServiceStack.OrmLite;

namespace eAuto.DS.Clases
{
    public class Modelo : IModelo
    {
        public OrmLiteConnectionFactory conexion;

        public Modelo()
        {
            conexion = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
        }
        public void ActualizarModelo(DATOS.Modelo modelo)
        {
            var db = conexion.Open();
            db.Update(modelo);
        }

        public DATOS.Modelo BuscarModelo(int idmodelo)
        {
            var db = conexion.Open();
            return db.Select<DATOS.Modelo>(x => x.IdModelo == idmodelo).FirstOrDefault();
        }

        public void EliminarModelo(int idmodelo)
        {
            var db = conexion.Open();
            db.Delete<DATOS.Modelo>(x => x.IdModelo == idmodelo);
        }

        public void InsertarModelo(DATOS.Modelo modelo)
        {
            var db = conexion.Open();
            db.Insert(modelo);
        }

        public List<DATOS.Modelo> ListarModelos()
        {
            var db = conexion.Open();
            return db.Select<DATOS.Modelo>();
        }
    }
}
