using eAuto.BL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eAuto.DATOS;

namespace eAuto.BL.Clases
{
    public class Usuario : IUsuario
    {
        public void ActualizarUsuario(DATOS.Usuario usuario)
        {
            DS.Interfaces.IUsuario usuarios = new DS.Clases.Usuario();
            usuarios.ActualizarUsuario(usuario);
        }

        public DATOS.Usuario BuscarUsuario(int idusuario)
        {
            DS.Interfaces.IUsuario usuarios = new DS.Clases.Usuario();
            return usuarios.BuscarUsuario(idusuario);
        }

        public void EliminarUsuario(int idusuario)
        {
            DS.Interfaces.IUsuario usuarios = new DS.Clases.Usuario();
            usuarios.EliminarUsuario(idusuario);
        }

        public void InsertarUsuario(DATOS.Usuario usuario)
        {
            DS.Interfaces.IUsuario usuarios = new DS.Clases.Usuario();
            usuarios.InsertarUsuario(usuario);
        }

        public List<DATOS.Usuario> ListarUsuario()
        {
            DS.Interfaces.IUsuario usuario = new DS.Clases.Usuario();
            return usuario.ListarUsuario();
        }
    }
}
