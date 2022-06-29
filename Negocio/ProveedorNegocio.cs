
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class ProveedorNegocio
    {
        public List<_Proveedor2> listar()
        {
            List<_Proveedor2> lista = new List<_Proveedor2>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select CUIT,NOMBRE_PROVEEDOR,TELEFONO,MAIL,DIRECCION FROM PROVEEDORES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Proveedor2 aux = new _Proveedor2();
                    aux.CUIT = (string)datos.Lector["CUIT"];
                    aux.Nombre = (string)datos.Lector["NOMBRE_PROVEEDOR"];
                    aux.Telefono = (string)datos.Lector["TELEFONO"];
                    aux.Mail = (string)datos.Lector["MAIL"];
                    aux.Direccion = (string)datos.Lector["DIRECCION"];

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
