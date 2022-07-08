using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using Negocio;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<_Marca> listar()
        {
            List<_Marca> lista = new List<_Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, DESCRIPCION_MARCA FROM MARCAS WHERE ACTIVO=1 ORDER BY DESCRIPCION_MARCA ASC");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Marca aux = new _Marca();
                    aux.IDMarca = (int)datos.Lector["Id"];
                    aux.DescripcionMarca = (string)datos.Lector["DESCRIPCION_MARCA"];

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

        public List<_Marca> listarxtexto(string texto)
        {
            List<_Marca> lista = new List<_Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, DESCRIPCION_MARCA FROM MARCAS WHERE ACTIVO=1 AND DESCRIPCION_MARCA LIKE CONCAT('%',@TEXTO,'%') ");
                datos.setearParametro("@TEXTO", texto);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Marca aux = new _Marca();
                    aux.IDMarca = (int)datos.Lector["Id"];
                    aux.DescripcionMarca = (string)datos.Lector["DESCRIPCION_MARCA"];

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

        public void agregar(_Marca nuevaMarca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO MARCAS (DESCRIPCION_MARCA,ACTIVO) VALUES ('" + nuevaMarca.DescripcionMarca + "','" + 1 + "' )");
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


        public void modificar(_Marca nuevaMarca)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE MARCAS SET DESCRIPCION_MARCA=@DESCRIPCION WHERE ID=@ID");
                datos.setearParametro("@ID", nuevaMarca.IDMarca);
                datos.setearParametro("@DESCRIPCION", nuevaMarca.DescripcionMarca);

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


        public void eliminar(int idEliminar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE MARCAS SET ACTIVO = 0 WHERE ID = @ID");
                datos.setearParametro("@ID", idEliminar);
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
