using System;
using System.Collections.Generic;
using ServiceStack.OrmLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eAuto.DS.Interfaces;
using eAuto.DATOS;

namespace eAuto.DS.Clases
{
    public class Marca : IMarca
    {
        public OrmLiteConnectionFactory conexion;

        public Marca()
        {
            conexion = new OrmLiteConnectionFactory(BD.Default.conexion,SqlServerDialect.Provider);
        }

        public void ActualizarMarca(DATOS.Marca marca)
        {
            var db = conexion.Open();
            db.Update(marca);
        }

        public DATOS.Marca BuscarMarca(int idmarca)
        {
            var db = conexion.Open();
            return db.Select<DATOS.Marca>(x => x.IdMarca == idmarca).FirstOrDefault();
        }

        public void EliminarMarca(int idmarca)
        {
            var db = conexion.Open();
            db.Delete<DATOS.Marca>(x => x.IdMarca == idmarca);
        }

        public void InsertarMarca(DATOS.Marca marca)
        {
            var db = conexion.Open();
            db.Insert(marca);
        }

        public List<DATOS.Marca> ListarMarcas()
        {
            var db = conexion.Open();
            return db.Select<DATOS.Marca>();
        }

        public List<DATOS.Marca> ListarMarcasPaises(string nombrepais)
        {
            var db = conexion.Open();
            List<DATOS.Marca> listapaises = db.Select<DATOS.Marca>(x => x.NombrePais == nombrepais);
            return listapaises;
        }
    }
}
