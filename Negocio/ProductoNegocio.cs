using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class ProductoNegocio
    {
        
        //public List<_Producto> listar()
        //{
        //    List<_Producto> lista = new List<_Producto>();
        //    AccesoDatos datos = new AccesoDatos();

        //    try
        //    {
        //        datos.setearConsulta("select Nombre FROM PRODUCTOS");
        //        datos.ejecutarLectura();

        //        while (datos.Lector.Read())
        //        {
        //            _Producto aux = new _Producto();
        //            /*aux.IDCategoria = (int)datos.Lector["Id"];
        //            aux.DescripcionCategoria = (string)datos.Lector["Descripcion"];*/

        //            lista.Add(aux);
        //        }

        //        return lista;
        //    }

        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }

        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }

        //}



        public void agregar(_Producto nuevoProducto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO PRODUCTOS (CODIGO,NOMBRE,IDMARCA,IDCATEGORIA,CUITPROVEEDOR,PRECIO,STOCKACTUAL,STOCKMINIMO,PORCENTAJEGANANCIA) " +
                    "VALUES ('" + nuevoProducto.Codigo + "', '" + nuevoProducto.Nombre + "', '" + "', @IDMARCA, @IDCATEGORIA, @CUITPROVEEDOR" + nuevoProducto.Precio + "', '" + nuevoProducto.StockActual + "', '" + nuevoProducto.StockMinimo + "', '" + nuevoProducto.PorcentajeGanancia + "')");
                datos.setearParametro("@IDMARCA", nuevoProducto.IDMarca);
                datos.setearParametro("@IDCATEGORIA", nuevoProducto.IDCategoria);
                datos.setearParametro("@CUITPROVEEDOR", nuevoProducto.CUITProveedor);
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
