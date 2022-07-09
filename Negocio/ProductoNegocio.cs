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
                datos.setearConsulta("select CODIGO,NOMBRE,IDMARCA,M.DESCRIPCION_MARCA,C.DESCRIPCION_CATEGORIA,IDCATEGORIA,PRECIO,PR.PRECIO_VENTA,STOCK_ACTUAL,STOCK_MINIMO,PORCENTAJE_GAN FROM PRODUCTOS PR INNER JOIN MARCAS M ON IDMARCA = M.ID INNER JOIN CATEGORIAS C ON IDCATEGORIA=C.ID WHERE PR.ACTIVO=1 ORDER BY NOMBRE ASC");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Producto aux = new _Producto();
                    aux.Marca = new _Marca();
                    aux.Categoria = new _Categoria();
                    //aux.Proveedor = new _Proveedor2();

                    aux.Codigo = (string)datos.Lector["CODIGO"];
                    aux.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.Marca.IDMarca = (int)datos.Lector["IDMARCA"];
                    aux.Marca.DescripcionMarca = (string)datos.Lector["DESCRIPCION_MARCA"];
                    aux.Categoria.IDCategoria = (int)datos.Lector["IDCATEGORIA"];
                    aux.Categoria.DescripcionCategoria = (string)datos.Lector["DESCRIPCION_CATEGORIA"];
                    //aux.Proveedor.CUIT = (string)datos.Lector["CUITPROVEEDOR"];
                    //aux.Proveedor.Nombre = (string)datos.Lector["NOMBRE_PROVEEDOR"];
                    aux.Precio = (decimal)datos.Lector["PRECIO"];
                    aux.PrecioVenta = (decimal)datos.Lector["PRECIO_VENTA"];
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


        public List<_Producto> listarConSP()
        {
            List<_Producto> lista = new List<_Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //datos.setearConsulta("select CODIGO,NOMBRE,IDMARCA,M.DESCRIPCION_MARCA,C.DESCRIPCION_CATEGORIA,IDCATEGORIA,PRECIO,PR.PRECIO_VENTA,STOCK_ACTUAL,STOCK_MINIMO,PORCENTAJE_GAN FROM PRODUCTOS PR INNER JOIN MARCAS M ON IDMARCA = M.ID INNER JOIN CATEGORIAS C ON IDCATEGORIA=C.ID WHERE PR.ACTIVO=1 ORDER BY NOMBRE ASC");

                datos.setearProcedimiento("storedListarArticulos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Producto aux = new _Producto();
                    aux.Marca = new _Marca();
                    aux.Categoria = new _Categoria();
                    //aux.Proveedor = new _Proveedor2();

                    aux.Codigo = (string)datos.Lector["CODIGO"];
                    aux.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.Marca.IDMarca = (int)datos.Lector["IDMARCA"];
                    aux.Marca.DescripcionMarca = (string)datos.Lector["DESCRIPCION_MARCA"];
                    aux.Categoria.IDCategoria = (int)datos.Lector["IDCATEGORIA"];
                    aux.Categoria.DescripcionCategoria = (string)datos.Lector["DESCRIPCION_CATEGORIA"];
                    //aux.Proveedor.CUIT = (string)datos.Lector["CUITPROVEEDOR"];
                    //aux.Proveedor.Nombre = (string)datos.Lector["NOMBRE_PROVEEDOR"];
                    aux.Precio = (decimal)datos.Lector["PRECIO"];
                    aux.PrecioVenta = (decimal)datos.Lector["PRECIO_VENTA"];
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


        public List<_Producto> listarxtexto(string texto)
        {
            List<_Producto> lista = new List<_Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select CODIGO,NOMBRE,IDMARCA,M.DESCRIPCION_MARCA,C.DESCRIPCION_CATEGORIA,IDCATEGORIA,PRECIO,PR.PRECIO_VENTA,STOCK_ACTUAL,STOCK_MINIMO,PORCENTAJE_GAN FROM PRODUCTOS PR INNER JOIN MARCAS M ON IDMARCA = M.ID INNER JOIN CATEGORIAS C ON IDCATEGORIA=C.ID WHERE PR.ACTIVO=1 AND PR.NOMBRE LIKE CONCAT('%',@TEXTO,'%') ");
                datos.setearParametro("@TEXTO", texto);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Producto aux = new _Producto();
                    aux.Marca = new _Marca();
                    aux.Categoria = new _Categoria();
                    //aux.Proveedor = new _Proveedor2();

                    aux.Codigo = (string)datos.Lector["CODIGO"];
                    aux.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.Marca.IDMarca = (int)datos.Lector["IDMARCA"];
                    aux.Marca.DescripcionMarca = (string)datos.Lector["DESCRIPCION_MARCA"];
                    aux.Categoria.IDCategoria = (int)datos.Lector["IDCATEGORIA"];
                    aux.Categoria.DescripcionCategoria = (string)datos.Lector["DESCRIPCION_CATEGORIA"];
                    //aux.Proveedor.CUIT = (string)datos.Lector["CUITPROVEEDOR"];
                    //aux.Proveedor.Nombre = (string)datos.Lector["NOMBRE_PROVEEDOR"];
                    aux.Precio = (decimal)datos.Lector["PRECIO"];
                    aux.PrecioVenta = (decimal)datos.Lector["PRECIO_VENTA"];
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


        public void agregarConSP(_Producto nuevoProducto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //datos.setearConsulta("INSERT INTO PRODUCTOS (CODIGO,PRECIO_VENTA,NOMBRE,IDMARCA,IDCATEGORIA,PRECIO,STOCK_ACTUAL,STOCK_MINIMO,PORCENTAJE_GAN,ACTIVO) " +
                //    "VALUES ('" + nuevoProducto.Codigo + "', '" + 0 + "', '" + nuevoProducto.Nombre + "', @IDMARCA, @IDCATEGORIA, " + nuevoProducto.Precio + ", '" + nuevoProducto.StockActual + "', '" + nuevoProducto.StockMinimo + "','" + nuevoProducto.PorcentajeGanancia + "', '" + 1 + "')");
                //datos.setearParametro("@IDMARCA", nuevoProducto.Marca.IDMarca);
                //datos.setearParametro("@IDCATEGORIA", nuevoProducto.Categoria.IDCategoria);

                //datos.setearParametro("@CUITPROVEEDOR", nuevoProducto.Proveedor.CUIT);

                datos.setearProcedimiento("storedAltaArticulos");
                datos.setearParametro("@CODIGO",nuevoProducto.Codigo);
                datos.setearParametro("@NOMBRE",nuevoProducto.Nombre);
                datos.setearParametro("@IDMARCA",nuevoProducto.Marca.IDMarca);
                datos.setearParametro("@IDCATEGORIA",nuevoProducto.Categoria.IDCategoria);
                datos.setearParametro("@PRECIO",nuevoProducto.Precio);
                datos.setearParametro("@STOCKACTUAL",nuevoProducto.StockActual);
                datos.setearParametro("@STOCKMINIMO",nuevoProducto.StockMinimo);
                datos.setearParametro("@PORCENTAJE",nuevoProducto.PorcentajeGanancia);
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


        public void modificar(_Producto nuevoProducto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE PRODUCTOS SET NOMBRE = @NOMBRE, IDMARCA = @IDMARCA, IDCATEGORIA = @IDCATEGORIA, PRECIO = @PRECIO, PRECIO_VENTA=@PRECIOVENTA, STOCK_ACTUAL = @STOCKACTUAL, STOCK_MINIMO = @STOCKMINIMO, PORCENTAJE_GAN = @PORCENTAJEGAN WHERE CODIGO = @CODIGO");
                datos.setearParametro("@CODIGO", nuevoProducto.Codigo);
                datos.setearParametro("@NOMBRE", nuevoProducto.Nombre);
                datos.setearParametro("@IDMARCA", nuevoProducto.Marca.IDMarca);
                datos.setearParametro("@IDCATEGORIA", nuevoProducto.Categoria.IDCategoria);

                datos.setearParametro("@PRECIO", nuevoProducto.Precio);
                datos.setearParametro("@PRECIOVENTA", nuevoProducto.Precio + (nuevoProducto.Precio * (nuevoProducto.PorcentajeGanancia / 100)));
                datos.setearParametro("@STOCKMINIMO", nuevoProducto.StockMinimo);
                datos.setearParametro("@STOCKACTUAL", nuevoProducto.StockActual);
                datos.setearParametro("@PORCENTAJEGAN", nuevoProducto.PorcentajeGanancia);
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

        public void modificarConSP(_Producto nuevoProducto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                //datos.setearConsulta("UPDATE PRODUCTOS SET NOMBRE = @NOMBRE, IDMARCA = @IDMARCA, IDCATEGORIA = @IDCATEGORIA, PRECIO = @PRECIO, PRECIO_VENTA=@PRECIOVENTA, STOCK_ACTUAL = @STOCKACTUAL, STOCK_MINIMO = @STOCKMINIMO, PORCENTAJE_GAN = @PORCENTAJEGAN WHERE CODIGO = @CODIGO");
                datos.setearProcedimiento("storedUpdateArticulos");
                datos.setearParametro("@CODIGO", nuevoProducto.Codigo);
                datos.setearParametro("@NOMBRE", nuevoProducto.Nombre);
                datos.setearParametro("@IDMARCA", nuevoProducto.Marca.IDMarca);
                datos.setearParametro("@IDCATEGORIA", nuevoProducto.Categoria.IDCategoria);

                datos.setearParametro("@PRECIO", nuevoProducto.Precio);
                datos.setearParametro("@PRECIOVENTA", nuevoProducto.Precio + (nuevoProducto.Precio * (nuevoProducto.PorcentajeGanancia / 100)));
                datos.setearParametro("@STOCKMINIMO", nuevoProducto.StockMinimo);
                datos.setearParametro("@STOCKACTUAL", nuevoProducto.StockActual);
                datos.setearParametro("@PORCENTAJE", nuevoProducto.PorcentajeGanancia);
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

        public void eliminar(string codigoEliminar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("UPDATE PRODUCTOS SET ACTIVO = 0 WHERE CODIGO = @CODIGO");
                datos.setearParametro("@CODIGO", codigoEliminar);
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


        public void limpiarRegistros(string cuit_proveedor, string cod_producto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM PROVEEDORES_X_PRODUCTO WHERE CODIGO_PRODUCTO=@CODIGO AND CUIT_PROVEEDOR=@CUIT");
                datos.setearParametro("@CODIGO", cod_producto);
                datos.setearParametro("@CUIT", cuit_proveedor);
                datos.ejecutarAccion();
                datos.cerrarConexion();

                datos.setearConsulta("INSERT INTO PROVEEDORES_X_PRODUCTO (CODIGO_PRODUCTO,CUIT_PROVEEDOR) " +
                    "VALUES ('" + cod_producto + "', '" + cuit_proveedor + "')");
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

        public void agregarProveedores(string cuit_proveedor, string cod_producto)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("DELETE FROM PROVEEDORES_X_PRODUCTO WHERE CODIGO_PRODUCTO=@CODIGO AND CUIT_PROVEEDOR=@CUIT");
                datos.setearParametro("@CODIGO", cod_producto);
                datos.setearParametro("@CUIT", cuit_proveedor);
                datos.ejecutarAccion();
                datos.cerrarConexion();

                datos.setearConsulta("INSERT INTO PROVEEDORES_X_PRODUCTO (CODIGO_PRODUCTO,CUIT_PROVEEDOR) " +
                    "VALUES ('" + cod_producto + "', '" + cuit_proveedor + "')");
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


        public decimal buscarPrecioVenta(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select PRECIO_VENTA from productos where codigo=@codigo");
                datos.setearParametro("@codigo", codigo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    decimal n = (decimal)datos.Lector["PRECIO_VENTA"];
                    string ns = String.Format("{0:0,00}", n);
                    n = decimal.Parse(ns);
                    return n;
                }
                else
                {
                    return 0;
                }


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


        public bool hayStock(decimal ingresado, string codigo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select stock_actual from productos where codigo=@codigo");
                datos.setearParametro("@codigo", codigo);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    decimal stockactual = (decimal)datos.Lector["stock_actual"];
                    if (ingresado <= stockactual)
                    {
                        return true;
                    }
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


        public decimal stockxproducto(string codigo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select stock_actual from productos where codigo=@codigo");
                datos.setearParametro("@codigo", codigo);
                datos.ejecutarLectura();

                decimal stockactual = 0;

                if (datos.Lector.Read())
                {
                    stockactual = (decimal)datos.Lector["stock_actual"];
                }

                return stockactual;



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