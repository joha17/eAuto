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
    public class Pais : IPais
    {

        public OrmLiteConnectionFactory conexion;

        public Pais()
        {
            conexion = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
        }

        public void ActualizarPais(DATOS.Pais pais)
        {
            var db = conexion.Open();
            db.Update(pais);
        }

        public DATOS.Pais BuscarPais(int idpais)
        {
            var db = conexion.Open();
            return db.Select<DATOS.Pais>(x => x.IdPais == idpais).FirstOrDefault();
        }

        public void EliminarPais(int idpais)
        {
            var db = conexion.Open();
            db.Delete<DATOS.Pais>(x => x.IdPais == idpais);
        }

        public void InsertarPais(DATOS.Pais pais)
        {
            var db = conexion.Open();
            db.Insert(pais);
        }

        public List<DATOS.Pais> ListarPaises()
        {
            var db = conexion.Open();
            return db.Select<DATOS.Pais>();
        }
    }
}
