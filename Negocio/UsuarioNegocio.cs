using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public bool loguear(_Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select ID_USUARIO, tipo_usuario, activo from usuarios where mail = @mail and contraseña = @contraseña");
                datos.setearParametro("@mail",usuario.Mail);
                datos.setearParametro("@contraseña", usuario.Contraseña);
                datos.ejecutarLectura();

                while(datos.Lector.Read())
                {
                    usuario.IDUsuario = (int)datos.Lector["ID_USUARIO"];
                    usuario.TipoUsuario = (int)datos.Lector["tipo_usuario"] == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    usuario.Activo = (int)datos.Lector["activo"];
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
