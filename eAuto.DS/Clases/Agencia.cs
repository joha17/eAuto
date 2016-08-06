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
    public class Agencia : IAgencia
    {
        public OrmLiteConnectionFactory conexion;

        public Agencia()
        {
            conexion = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
        }

        public void ActualizarAgencia(DATOS.Agencia agencia)
        {
            var db = conexion.Open();
            db.Update(agencia);
        }

        public DATOS.Agencia BuscarAgencia(int idagencia)
        {
            var db = conexion.Open();
            return db.Select<DATOS.Agencia>(x => x.IdAgencia == idagencia).FirstOrDefault();
        }

        public void EliminarAgencia(int idagencia)
        {
            var db = conexion.Open();
            db.Delete<DATOS.Agencia>(x => x.IdAgencia == idagencia);
        }

        public void InsertarAgencia(DATOS.Agencia agencia)
        {
            var db = conexion.Open();
            db.Insert(agencia);
        }

        public List<DATOS.Agencia> ListarAgencia()
        {
            var db = conexion.Open();
            return db.Select<DATOS.Agencia>();
        }
    }
}
