
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
                datos.setearConsulta("select CUIT,NOMBRE_PROVEEDOR,TELEFONO,MAIL,DIRECCION FROM PROVEEDORES WHERE ACTIVO=1");
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


        public void agregar(_Proveedor2 nuevoProveedor)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO PROVEEDORES (CUIT,NOMBRE_PROVEEDOR,TELEFONO,MAIL,DIRECCION, ACTIVO) VALUES ('" + nuevoProveedor.CUIT + "','" + nuevoProveedor.Nombre + "','" + nuevoProveedor.Telefono + "','" + nuevoProveedor.Mail + "','" + nuevoProveedor.Direccion + "','" + 1 + "' )");
                datos.ejecutarAccion();
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


        public void modificar(_Proveedor2 nuevoProveedor)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE PROVEEDORES SET CUIT=@CUIT,NOMBRE_PROVEEDOR=@NOMBRE,TELEFONO=@TELEFONO,MAIL=@MAIL,DIRECCION=@DIRECCION WHERE CUIT=@CUIT");
                datos.setearParametro("@CUIT", nuevoProveedor.CUIT);
                datos.setearParametro("@NOMBRE", nuevoProveedor.Nombre);
                datos.setearParametro("@TELEFONO", nuevoProveedor.Telefono);
                datos.setearParametro("@MAIL", nuevoProveedor.Mail);
                datos.setearParametro("@DIRECCION", nuevoProveedor.Direccion);

                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                //el producto ya existe
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public void eliminar(string cuitEliminar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE PROVEEDORES SET ACTIVO = 0 WHERE CUIT = @CUIT");
                datos.setearParametro("@CUIT", cuitEliminar);
                datos.ejecutarAccion();
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


        public List<String> listarProveedoresAsociados(string buscado)
        {
            List<String> lista = new List<String>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select P.NOMBRE_PROVEEDOR FROM PROVEEDORES AS P INNER JOIN PROVEEDORES_X_PRODUCTO PXP ON P.CUIT = PXP.CUIT_PROVEEDOR INNER JOIN PRODUCTOS AS PR ON PR.CODIGO = PXP.CODIGO_PRODUCTO WHERE PR.CODIGO = @BUSCADO");
                datos.setearParametro("@BUSCADO", buscado);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    string aux = (string)datos.Lector["NOMBRE_PROVEEDOR"];
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


        public List<String> listarProveedores()
        {
            List<String> lista = new List<String>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select NOMBRE_PROVEEDOR FROM PROVEEDORES WHERE ACTIVO=1");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    string aux = (string)datos.Lector["NOMBRE_PROVEEDOR"];
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
