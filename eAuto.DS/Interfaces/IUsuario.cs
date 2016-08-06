using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAuto.DS.Interfaces
{
    public interface IUsuario
    {
        List<DATOS.Usuario> ListarUsuario();
        DATOS.Usuario BuscarUsuario(int idusuario);
        void InsertarUsuario(DATOS.Usuario usuario);
        void ActualizarUsuario(DATOS.Usuario usuario);
        void EliminarUsuario(int idusuario);
    }
}
