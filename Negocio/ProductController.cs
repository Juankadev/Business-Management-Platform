using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class ProductController
    {
        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();
            DataAccess data = new DataAccess();

            try
            {
                data.SetQuery("select CODIGO,NOMBRE,IDMARCA,M.DESCRIPCION_MARCA,C.DESCRIPCION_CATEGORIA,IDCATEGORIA,PRECIO,PR.PRECIO_VENTA,STOCK_ACTUAL,STOCK_MINIMO,PORCENTAJE_GAN FROM PRODUCTOS PR INNER JOIN MARCAS M ON IDMARCA = M.ID INNER JOIN CATEGORIAS C ON IDCATEGORIA=C.ID WHERE PR.ACTIVO=1 ORDER BY NOMBRE ASC");
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Product aux = new Product();
                    aux.brand = new Brand();
                    aux.category = new Category();
                    //aux.Proveedor = new _Proveedor2();

                    aux.code = (string)data.Reader["CODIGO"];
                    aux.name = (string)data.Reader["NOMBRE"];
                    aux.brand.id = (int)data.Reader["IDMARCA"];
                    aux.brand.description = (string)data.Reader["DESCRIPCION_MARCA"];
                    aux.category.id = (int)data.Reader["IDCATEGORIA"];
                    aux.category.description = (string)data.Reader["DESCRIPCION_CATEGORIA"];
                    //aux.Proveedor.CUIT = (string)datos.Lector["CUITPROVEEDOR"];
                    //aux.Proveedor.Nombre = (string)datos.Lector["NOMBRE_PROVEEDOR"];
                    aux.price = (decimal)data.Reader["PRECIO"];
                    aux.PrecioVenta = (decimal)data.Reader["PRECIO_VENTA"];
                    aux.currentStock = (decimal)data.Reader["STOCK_ACTUAL"];
                    aux.minimumStock = (decimal)data.Reader["STOCK_MINIMO"];
                    aux.percentageOfProfit = (decimal)data.Reader["PORCENTAJE_GAN"];

                    list.Add(aux);
                }

                return list;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                data.Close();
            }

        }
        public List<Product> GetAllFromStoredProcedure()
        {
            List<Product> list = new List<Product>();
            DataAccess data = new DataAccess();

            try
            {
                //datos.setearConsulta("select CODIGO,NOMBRE,IDMARCA,M.DESCRIPCION_MARCA,C.DESCRIPCION_CATEGORIA,IDCATEGORIA,PRECIO,PR.PRECIO_VENTA,STOCK_ACTUAL,STOCK_MINIMO,PORCENTAJE_GAN FROM PRODUCTOS PR INNER JOIN MARCAS M ON IDMARCA = M.ID INNER JOIN CATEGORIAS C ON IDCATEGORIA=C.ID WHERE PR.ACTIVO=1 ORDER BY NOMBRE ASC");

                data.SetProcedure("storedListarArticulos");
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Product aux = new Product();
                    aux.brand = new Brand();
                    aux.category = new Category();
                    //aux.Proveedor = new _Proveedor2();

                    aux.code = (string)data.Reader["CODIGO"];
                    aux.name = (string)data.Reader["NOMBRE"];
                    aux.brand.id = (int)data.Reader["IDMARCA"];
                    aux.brand.description = (string)data.Reader["DESCRIPCION_MARCA"];
                    aux.category.id = (int)data.Reader["IDCATEGORIA"];
                    aux.category.description = (string)data.Reader["DESCRIPCION_CATEGORIA"];
                    //aux.Proveedor.CUIT = (string)datos.Lector["CUITPROVEEDOR"];
                    //aux.Proveedor.Nombre = (string)datos.Lector["NOMBRE_PROVEEDOR"];
                    aux.price = (decimal)data.Reader["PRECIO"];
                    aux.PrecioVenta = (decimal)data.Reader["PRECIO_VENTA"];
                    aux.currentStock = (decimal)data.Reader["STOCK_ACTUAL"];
                    aux.minimumStock = (decimal)data.Reader["STOCK_MINIMO"];
                    aux.percentageOfProfit = (decimal)data.Reader["PORCENTAJE_GAN"];

                    list.Add(aux);
                }

                return list;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                data.Close();
            }
        }
        public List<Product> GetAllByPartialDescription(string description)
        {
            List<Product> list = new List<Product>();
            DataAccess data = new DataAccess();

            try
            {
                data.SetQuery("select CODIGO,NOMBRE,IDMARCA,M.DESCRIPCION_MARCA,C.DESCRIPCION_CATEGORIA,IDCATEGORIA,PRECIO,PR.PRECIO_VENTA,STOCK_ACTUAL,STOCK_MINIMO,PORCENTAJE_GAN FROM PRODUCTOS PR INNER JOIN MARCAS M ON IDMARCA = M.ID INNER JOIN CATEGORIAS C ON IDCATEGORIA=C.ID WHERE PR.ACTIVO=1 AND PR.NOMBRE LIKE CONCAT('%',@TEXTO,'%') ");
                data.SetParameter("@TEXTO", description);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Product aux = new Product();
                    aux.brand = new Brand();
                    aux.category = new Category();
                    //aux.Proveedor = new _Proveedor2();

                    aux.code = (string)data.Reader["CODIGO"];
                    aux.name = (string)data.Reader["NOMBRE"];
                    aux.brand.id = (int)data.Reader["IDMARCA"];
                    aux.brand.description = (string)data.Reader["DESCRIPCION_MARCA"];
                    aux.category.id = (int)data.Reader["IDCATEGORIA"];
                    aux.category.description = (string)data.Reader["DESCRIPCION_CATEGORIA"];
                    //aux.Proveedor.CUIT = (string)datos.Lector["CUITPROVEEDOR"];
                    //aux.Proveedor.Nombre = (string)datos.Lector["NOMBRE_PROVEEDOR"];
                    aux.price = (decimal)data.Reader["PRECIO"];
                    aux.PrecioVenta = (decimal)data.Reader["PRECIO_VENTA"];
                    aux.currentStock = (decimal)data.Reader["STOCK_ACTUAL"];
                    aux.minimumStock = (decimal)data.Reader["STOCK_MINIMO"];
                    aux.percentageOfProfit = (decimal)data.Reader["PORCENTAJE_GAN"];

                    list.Add(aux);
                }

                return list;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                data.Close();
            }

        }
        public void AddFromStoredProcedure(Product product)
        {
            DataAccess data = new DataAccess();
            try
            {
                //datos.setearConsulta("INSERT INTO PRODUCTOS (CODIGO,PRECIO_VENTA,NOMBRE,IDMARCA,IDCATEGORIA,PRECIO,STOCK_ACTUAL,STOCK_MINIMO,PORCENTAJE_GAN,ACTIVO) " +
                //    "VALUES ('" + nuevoProducto.Codigo + "', '" + 0 + "', '" + nuevoProducto.Nombre + "', @IDMARCA, @IDCATEGORIA, " + nuevoProducto.Precio + ", '" + nuevoProducto.StockActual + "', '" + nuevoProducto.StockMinimo + "','" + nuevoProducto.PorcentajeGanancia + "', '" + 1 + "')");
                //datos.setearParametro("@IDMARCA", nuevoProducto.Marca.IDMarca);
                //datos.setearParametro("@IDCATEGORIA", nuevoProducto.Categoria.IDCategoria);

                //datos.setearParametro("@CUITPROVEEDOR", nuevoProducto.Proveedor.CUIT);

                data.SetProcedure("storedAltaArticulos");
                data.SetParameter("@CODIGO",product.code);
                data.SetParameter("@NOMBRE",product.name);
                data.SetParameter("@IDMARCA",product.brand.id);
                data.SetParameter("@IDCATEGORIA",product.category.id);
                data.SetParameter("@PRECIO",product.price);
                data.SetParameter("@STOCKACTUAL",product.currentStock);
                data.SetParameter("@STOCKMINIMO",product.minimumStock);
                data.SetParameter("@PORCENTAJE",product.percentageOfProfit);
                data.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //el producto ya existe
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }
        public void Modify(Product product)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.SetQuery("UPDATE PRODUCTOS SET NOMBRE = @NOMBRE, IDMARCA = @IDMARCA, IDCATEGORIA = @IDCATEGORIA, PRECIO = @PRECIO, PRECIO_VENTA=@PRECIOVENTA, STOCK_ACTUAL = @STOCKACTUAL, STOCK_MINIMO = @STOCKMINIMO, PORCENTAJE_GAN = @PORCENTAJEGAN WHERE CODIGO = @CODIGO");
                data.SetParameter("@CODIGO", product.code);
                data.SetParameter("@NOMBRE", product.name);
                data.SetParameter("@IDMARCA", product.brand.id);
                data.SetParameter("@IDCATEGORIA", product.category.id);

                data.SetParameter("@PRECIO", product.price);
                data.SetParameter("@PRECIOVENTA", product.price + (product.price * (product.percentageOfProfit / 100)));
                data.SetParameter("@STOCKMINIMO", product.minimumStock);
                data.SetParameter("@STOCKACTUAL", product.currentStock);
                data.SetParameter("@PORCENTAJEGAN", product.percentageOfProfit);
                data.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //el producto ya existe
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }
        public void ModifyFromStoredProcedure(Product product)
        {
            DataAccess data = new DataAccess();
            try
            {
                //datos.setearConsulta("UPDATE PRODUCTOS SET NOMBRE = @NOMBRE, IDMARCA = @IDMARCA, IDCATEGORIA = @IDCATEGORIA, PRECIO = @PRECIO, PRECIO_VENTA=@PRECIOVENTA, STOCK_ACTUAL = @STOCKACTUAL, STOCK_MINIMO = @STOCKMINIMO, PORCENTAJE_GAN = @PORCENTAJEGAN WHERE CODIGO = @CODIGO");
                data.SetProcedure("storedUpdateArticulos");
                data.SetParameter("@CODIGO", product.code);
                data.SetParameter("@NOMBRE", product.name);
                data.SetParameter("@IDMARCA", product.brand.id);
                data.SetParameter("@IDCATEGORIA", product.category.id);

                data.SetParameter("@PRECIO", product.price);
                data.SetParameter("@PRECIOVENTA", product.price + (product.price * (product.percentageOfProfit / 100)));
                data.SetParameter("@STOCKMINIMO", product.minimumStock);
                data.SetParameter("@STOCKACTUAL", product.currentStock);
                data.SetParameter("@PORCENTAJE", product.percentageOfProfit);
                data.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                //el producto ya existe
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }
        public void Delete(string productCode)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.SetQuery("UPDATE PRODUCTOS SET ACTIVO = 0 WHERE CODIGO = @CODIGO");
                data.SetParameter("@CODIGO", productCode);
                data.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }
        //public void limpiarRegistros(string cuit_proveedor, string cod_producto)
        //{
        //    DataAccess datos = new DataAccess();
        //    try
        //    {
        //        datos.SetQuery("DELETE FROM PROVEEDORES_X_PRODUCTO WHERE CODIGO_PRODUCTO=@CODIGO AND CUIT_PROVEEDOR=@CUIT");
        //        datos.SetParameter("@CODIGO", cod_producto);
        //        datos.SetParameter("@CUIT", cuit_proveedor);
        //        datos.ExecuteNonQuery();
        //        datos.Close();

        //        datos.SetQuery("INSERT INTO PROVEEDORES_X_PRODUCTO (CODIGO_PRODUCTO,CUIT_PROVEEDOR) " +
        //            "VALUES ('" + cod_producto + "', '" + cuit_proveedor + "')");
        //        datos.ExecuteNonQuery();
        //    }
        //    catch (Exception ex)
        //    {
        //        //el producto ya existe
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.Close();
        //    }
        //}
        public void AddSuppliers(string cuit, string productCode)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.SetQuery("DELETE FROM PROVEEDORES_X_PRODUCTO WHERE CODIGO_PRODUCTO=@CODIGO AND CUIT_PROVEEDOR=@CUIT");
                data.SetParameter("@CODIGO", productCode);
                data.SetParameter("@CUIT", cuit);
                data.ExecuteNonQuery();
                data.Close();

                data.SetQuery("INSERT INTO PROVEEDORES_X_PRODUCTO (CODIGO_PRODUCTO,CUIT_PROVEEDOR) " +
                    "VALUES ('" + productCode + "', '" + cuit + "')");
                data.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }
        public decimal GetSalePrice(string productCode)
        {
            DataAccess data = new DataAccess();

            try
            {
                data.SetQuery("select PRECIO_VENTA from productos where codigo=@codigo");
                data.SetParameter("@codigo", productCode);
                data.ExecuteReader();

                if (data.Reader.Read())
                {
                    decimal price = (decimal)data.Reader["PRECIO_VENTA"];
                    string formattedPrice = String.Format("{0:0,00}", price);
                    price = decimal.Parse(formattedPrice);
                    return price;
                }

                return 0;
            }

            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                data.Close();
            }
        }
        public bool ExistStock(decimal quantity, string productCode)
        {
            DataAccess data = new DataAccess();

            try
            {
                data.SetQuery("select stock_actual from productos where codigo=@codigo");
                data.SetParameter("@codigo", productCode);
                data.ExecuteReader();

                if (data.Reader.Read())
                {
                    decimal currentStock = (decimal)data.Reader["stock_actual"];
                    if (quantity <= currentStock)
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
                data.Close();
            }
        }
        public decimal GetCurrentStock(string productCode)
        {
            DataAccess data = new DataAccess();

            try
            {
                data.SetQuery("select stock_actual from productos where codigo=@codigo");
                data.SetParameter("@codigo", productCode);
                data.ExecuteReader();

                decimal currentStock = 0;

                if (data.Reader.Read())
                {
                    currentStock = (decimal)data.Reader["stock_actual"];
                }
                return currentStock;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                data.Close();
            }

        }
    }
}