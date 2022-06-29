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
                datos.setearConsulta("select DNI,APELLIDO,NOMBRE,TELEFONO,MAIL,DIRECCION FROM CLIENTES");
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
                datos.setearConsulta("INSERT INTO CLIENTES (DNI,APELLIDO,NOMBRE,TELEFONO,MAIL,DIRECCION) VALUES ('" + nuevoCliente.DNI + "','" + nuevoCliente.Apellido + "','" + nuevoCliente.Nombre + "','" + nuevoCliente.Telefono + "','" + nuevoCliente.Mail + "','" + nuevoCliente.Direccion + "' )");
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
