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
    public class Usuario : IUsuario
    {
        public OrmLiteConnectionFactory conexion;

        public Usuario()
        {
            conexion = new OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
        }

        public void ActualizarUsuario(DATOS.Usuario usuario)
        {
            var db = conexion.Open();
            db.Update(usuario);
        }

        public DATOS.Usuario BuscarUsuario(int idusuario)
        {
            var db = conexion.Open();
            return db.Select<DATOS.Usuario>(x => x.IdUsuario == idusuario).FirstOrDefault();
        }

        public void EliminarUsuario(int idusuario)
        {
            var db = conexion.Open();
            db.Delete<DATOS.Usuario>(x => x.IdUsuario == idusuario);
        }

        public void InsertarUsuario(DATOS.Usuario usuario)
        {
            var db = conexion.Open();
            db.Insert(usuario);
        }

        public List<DATOS.Usuario> ListarUsuario()
        {
            var db = conexion.Open();
            return db.Select<DATOS.Usuario>();
        }
    }
}
