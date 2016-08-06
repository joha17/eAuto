using ServiceStack.OrmLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAuto.DS
{
    public class Conexion
    {
        public static OrmLiteConnectionFactory EstablecerConexion()
        {
            return new
                OrmLiteConnectionFactory(BD.Default.conexion, SqlServerDialect.Provider);
        }
    }
}
