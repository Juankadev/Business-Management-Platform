using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<_Categoria> listar()
        {
            List<_Categoria> lista = new List<_Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, DESCRIPCION_CATEGORIA FROM CATEGORIAS WHERE ACTIVO=1 order by DESCRIPCION_CATEGORIA asc");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Categoria aux = new _Categoria();
                    aux.IDCategoria = (int)datos.Lector["Id"];
                    aux.DescripcionCategoria = (string)datos.Lector["DESCRIPCION_CATEGORIA"];

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



        public void agregar(_Categoria nuevaCategoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO CATEGORIAS (DESCRIPCION_CATEGORIA, ACTIVO) VALUES ('" + nuevaCategoria.DescripcionCategoria + "','" + 1 + "' )");
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


        public void modificar(_Categoria nuevaCategoria)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE CATEGORIAS SET DESCRIPCION_CATEGORIA=@DESCRIPCION WHERE ID=@ID");
                datos.setearParametro("@ID", nuevaCategoria.IDCategoria);
                datos.setearParametro("@DESCRIPCION", nuevaCategoria.DescripcionCategoria);

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
                datos.setearConsulta("UPDATE CATEGORIAS SET ACTIVO = 0 WHERE ID = @ID");
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
