using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ClienteNegocio
    {
        public List<_Cliente> listar()
        {
            List<_Cliente> lista = new List<_Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select DNI,APELLIDO,NOMBRE,TELEFONO,MAIL,DIRECCION FROM CLIENTES WHERE ACTIVO=1 order by APELLIDO asc");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Cliente aux = new _Cliente();
   
                    aux.DNI = (string)datos.Lector["DNI"];
                    aux.Apellido = (string)datos.Lector["APELLIDO"];
                    aux.Nombre = (string)datos.Lector["NOMBRE"];
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

        public void agregar(_Cliente nuevoCliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO CLIENTES (DNI,APELLIDO,NOMBRE,TELEFONO,MAIL,DIRECCION,ACTIVO) VALUES ('" + nuevoCliente.DNI + "','" + nuevoCliente.Apellido + "','" + nuevoCliente.Nombre + "','" + nuevoCliente.Telefono + "','" + nuevoCliente.Mail + "','" + nuevoCliente.Direccion + "','" + 1 + "' )");
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


        public void modificar(_Cliente nuevoCliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE CLIENTES SET DNI=@DNI,NOMBRE=@NOMBRE,APELLIDO=@APELLIDO,TELEFONO=@TELEFONO,MAIL=@MAIL,DIRECCION=@DIRECCION WHERE DNI=@DNI");
                datos.setearParametro("@DNI", nuevoCliente.DNI);
                datos.setearParametro("@NOMBRE", nuevoCliente.Nombre);
                datos.setearParametro("@APELLIDO", nuevoCliente.Apellido);
                datos.setearParametro("@TELEFONO", nuevoCliente.Telefono);
                datos.setearParametro("@MAIL", nuevoCliente.Mail);
                datos.setearParametro("@DIRECCION", nuevoCliente.Direccion);

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


        public void eliminar(string idEliminar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE CLIENTES SET ACTIVO = 0 WHERE DNI = @DNI");
                datos.setearParametro("@DNI", idEliminar);
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
    }
}
