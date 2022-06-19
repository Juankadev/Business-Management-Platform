
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class _ProveedorNegocio
    {
        public List<_Proveedor2> listar()
        {
            List<_Proveedor2> lista = new List<_Proveedor2>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select CUIT, Nombre FROM PROVEEDORES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Proveedor2 aux = new _Proveedor2();
                    aux.CUIT = (string)datos.Lector["CUIT"];
                    aux.Nombre = (string)datos.Lector["Nombre"];

                    lista.Add(aux);
                }

                return lista;
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
