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

        public List<_Producto> listar()
        {
            List<_Producto> lista = new List<_Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select CODIGO,NOMBRE,IDMARCA,M.DESCRIPCION_MARCA,C.DESCRIPCION_CATEGORIA,IDCATEGORIA,CUITPROVEEDOR,P.NOMBRE_PROVEEDOR,PRECIO,STOCK_ACTUAL,STOCK_MINIMO,PORCENTAJE_GAN FROM PRODUCTOS INNER JOIN MARCAS M ON IDMARCA = M.ID INNER JOIN CATEGORIAS C ON IDCATEGORIA=C.ID INNER JOIN PROVEEDORES P ON CUITPROVEEDOR=P.CUIT");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Producto aux = new _Producto();
                    aux.Marca = new _Marca();
                    aux.Categoria = new _Categoria();
                    aux.Proveedor = new _Proveedor2();

                    aux.Codigo = (string)datos.Lector["CODIGO"];
                    aux.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.Marca.IDMarca = (int)datos.Lector["IDMARCA"];
                    aux.Marca.DescripcionMarca = (string)datos.Lector["DESCRIPCION_MARCA"];
                    aux.Categoria.IDCategoria = (int)datos.Lector["IDCATEGORIA"];
                    aux.Categoria.DescripcionCategoria = (string)datos.Lector["DESCRIPCION_CATEGORIA"];
                    aux.Proveedor.CUIT = (string)datos.Lector["CUITPROVEEDOR"];
                    aux.Proveedor.Nombre = (string)datos.Lector["NOMBRE_PROVEEDOR"];
                    aux.Precio = (decimal)datos.Lector["PRECIO"];
                    aux.StockActual = (decimal)datos.Lector["STOCK_ACTUAL"];
                    aux.StockMinimo = (decimal)datos.Lector["STOCK_MINIMO"];
                    aux.PorcentajeGanancia = (decimal)datos.Lector["PORCENTAJE_GAN"];

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



        public void agregar(_Producto nuevoProducto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO PRODUCTOS (CODIGO,NOMBRE,IDMARCA,IDCATEGORIA,CUITPROVEEDOR,PRECIO,STOCK_ACTUAL,STOCK_MINIMO,PORCENTAJE_GAN) " +
                    "VALUES ('" + nuevoProducto.Codigo + "', '" + nuevoProducto.Nombre + "', @IDMARCA, @IDCATEGORIA, @CUITPROVEEDOR, " + nuevoProducto.Precio + ", '" + nuevoProducto.StockActual + "', '" + nuevoProducto.StockMinimo + "','" + nuevoProducto.PorcentajeGanancia + "')");
                datos.setearParametro("@IDMARCA", nuevoProducto.Marca.IDMarca);
                datos.setearParametro("@IDCATEGORIA", nuevoProducto.Categoria.IDCategoria);
                datos.setearParametro("@CUITPROVEEDOR", nuevoProducto.Proveedor.CUIT);
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
