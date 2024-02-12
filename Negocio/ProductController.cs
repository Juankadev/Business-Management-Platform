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
        DataAccess data = new DataAccess();
        public List<Product> GetAll()
        {
            List<Product> list = new List<Product>();

            try
            {
                data.SetQuery("select CODIGO,NOMBRE,IDMARCA,M.DESCRIPCION_MARCA,C.DESCRIPCION_CATEGORIA,IDCATEGORIA,PRECIO,PR.PRECIO_VENTA,STOCK_ACTUAL,STOCK_MINIMO,PORCENTAJE_GAN FROM PRODUCTOS PR INNER JOIN MARCAS M ON IDMARCA = M.ID INNER JOIN CATEGORIAS C ON IDCATEGORIA=C.ID WHERE PR.ACTIVO=1 ORDER BY NOMBRE ASC");
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Product product = new Product();
                    product.brand = new Brand();
                    product.category = new Category();
  
                    product.code = (string)data.Reader["CODIGO"];
                    product.name = (string)data.Reader["NOMBRE"];
                    product.brand.id = (int)data.Reader["IDMARCA"];
                    product.brand.description = (string)data.Reader["DESCRIPCION_MARCA"];
                    product.category.id = (int)data.Reader["IDCATEGORIA"];
                    product.category.description = (string)data.Reader["DESCRIPCION_CATEGORIA"];
                    product.price = (decimal)data.Reader["PRECIO"];
                    product.salePrice = (decimal)data.Reader["PRECIO_VENTA"];
                    product.currentStock = (decimal)data.Reader["STOCK_ACTUAL"];
                    product.minimumStock = (decimal)data.Reader["STOCK_MINIMO"];
                    product.percentageOfProfit = (decimal)data.Reader["PORCENTAJE_GAN"];

                    list.Add(product);
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

            try
            {
                //datos.setearConsulta("select CODIGO,NOMBRE,IDMARCA,M.DESCRIPCION_MARCA,C.DESCRIPCION_CATEGORIA,IDCATEGORIA,PRECIO,PR.PRECIO_VENTA,STOCK_ACTUAL,STOCK_MINIMO,PORCENTAJE_GAN FROM PRODUCTOS PR INNER JOIN MARCAS M ON IDMARCA = M.ID INNER JOIN CATEGORIAS C ON IDCATEGORIA=C.ID WHERE PR.ACTIVO=1 ORDER BY NOMBRE ASC");

                data.SetProcedure("storedListarArticulos");
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Product product = new Product();
                    product.brand = new Brand();
                    product.category = new Category();

                    product.code = (string)data.Reader["CODIGO"];
                    product.name = (string)data.Reader["NOMBRE"];
                    product.brand.id = (int)data.Reader["IDMARCA"];
                    product.brand.description = (string)data.Reader["DESCRIPCION_MARCA"];
                    product.category.id = (int)data.Reader["IDCATEGORIA"];
                    product.category.description = (string)data.Reader["DESCRIPCION_CATEGORIA"];
                    product.price = (decimal)data.Reader["PRECIO"];
                    product.salePrice = (decimal)data.Reader["PRECIO_VENTA"];
                    product.currentStock = (decimal)data.Reader["STOCK_ACTUAL"];
                    product.minimumStock = (decimal)data.Reader["STOCK_MINIMO"];
                    product.percentageOfProfit = (decimal)data.Reader["PORCENTAJE_GAN"];

                    list.Add(product);
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

            try
            {
                data.SetQuery("select CODIGO,NOMBRE,IDMARCA,M.DESCRIPCION_MARCA,C.DESCRIPCION_CATEGORIA,IDCATEGORIA,PRECIO,PR.PRECIO_VENTA,STOCK_ACTUAL,STOCK_MINIMO,PORCENTAJE_GAN FROM PRODUCTOS PR INNER JOIN MARCAS M ON IDMARCA = M.ID INNER JOIN CATEGORIAS C ON IDCATEGORIA=C.ID WHERE PR.ACTIVO=1 AND PR.NOMBRE LIKE CONCAT('%',@TEXTO,'%') ");
                data.SetParameter("@TEXTO", description);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Product product = new Product();
                    product.brand = new Brand();
                    product.category = new Category();

                    product.code = (string)data.Reader["CODIGO"];
                    product.name = (string)data.Reader["NOMBRE"];
                    product.brand.id = (int)data.Reader["IDMARCA"];
                    product.brand.description = (string)data.Reader["DESCRIPCION_MARCA"];
                    product.category.id = (int)data.Reader["IDCATEGORIA"];
                    product.category.description = (string)data.Reader["DESCRIPCION_CATEGORIA"];
                    product.price = (decimal)data.Reader["PRECIO"];
                    product.salePrice = (decimal)data.Reader["PRECIO_VENTA"];
                    product.currentStock = (decimal)data.Reader["STOCK_ACTUAL"];
                    product.minimumStock = (decimal)data.Reader["STOCK_MINIMO"];
                    product.percentageOfProfit = (decimal)data.Reader["PORCENTAJE_GAN"];

                    list.Add(product);
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
        public void Add(Product product)
        {
            try
            {
                data.SetProcedure("SP_ADD_PRODUCTO");
                data.SetParameter("@CODIGO",product.code);
                data.SetParameter("@PRECIO_VENTA", product.salePrice);
                data.SetParameter("@NOMBRE",product.name);
                data.SetParameter("@IDMARCA",product.brand.id);
                data.SetParameter("@IDCATEGORIA",product.category.id);
                data.SetParameter("@PRECIO",product.price);
                data.SetParameter("@STOCK_ACTUAL",product.currentStock);
                data.SetParameter("@STOCK_MINIMO",product.minimumStock);
                data.SetParameter("@PORCENTAJE_GAN", product.percentageOfProfit);
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
        public void Modify(Product product)
        {
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
                throw ex;
            }
            finally
            {
                data.Close();
            }
        }
        public void ModifyFromStoredProcedure(Product product)
        {
            try
            {
                data.SetProcedure("SP_UPDATE_PRODUCTO");
                data.SetParameter("@CODIGO", product.code);
                data.SetParameter("@NOMBRE", product.name);
                data.SetParameter("@IDMARCA", product.brand.id);
                data.SetParameter("@IDCATEGORIA", product.category.id);
                data.SetParameter("@PRECIO", product.price);
                data.SetParameter("@PRECIO_VENTA", product.price + (product.price * (product.percentageOfProfit / 100)));
                data.SetParameter("@STOCK_MINIMO", product.minimumStock);
                data.SetParameter("@STOCK_ACTUAL", product.currentStock);
                data.SetParameter("@PORCENTAJE_GAN", product.percentageOfProfit);
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
        public void Delete(string productCode)
        {
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