﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class PurchaseController
    {
        DataAccess data = new DataAccess();
        public List<Purchase> GetAll()
        {
            List<Purchase> list = new List<Purchase>();
            try
            {
                data.SetQuery("select NUM_COMPRA, COD_PROVEEDOR, P.NOMBRE_PROVEEDOR, TOTAL, C.FECHA FROM COMPRAS C INNER JOIN PROVEEDORES P ON C.COD_PROVEEDOR = P.CUIT order by NUM_COMPRA desc");
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Purchase purchase = new Purchase();
                    purchase.supplier = new Supplier();

                    purchase.number = (int)data.Reader["NUM_COMPRA"];
                    purchase.supplier.cuit = (string)data.Reader["COD_PROVEEDOR"];
                    purchase.supplier.name = (string)data.Reader["NOMBRE_PROVEEDOR"];
                    purchase.total = (Decimal)data.Reader["TOTAL"];
                    purchase.date = (DateTime)data.Reader["FECHA"];

                    list.Add(purchase);
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
        public Purchase GetByNumber(int number)
        {
            try
            {
                data.SetQuery("select C.NUM_COMPRA, C.COD_PROVEEDOR, P.NOMBRE_PROVEEDOR, C.TOTAL, C.FECHA, D.OBSERVACIONES, D.CONDICION_PAGO FROM COMPRAS C INNER JOIN PROVEEDORES P ON C.COD_PROVEEDOR = P.CUIT INNER JOIN DETALLE_COMPRA D ON D.DETALLE_COMPRA = C.NUM_COMPRA WHERE C.NUM_COMPRA = @BUSCADO");
                data.SetParameter("@BUSCADO", number);
                data.ExecuteReader();

                Purchase purchase = new Purchase();
                purchase.supplier = new Supplier();

                while (data.Reader.Read())
                {
                    purchase.number = (int)data.Reader["NUM_COMPRA"];
                    purchase.supplier.cuit = (string)data.Reader["COD_PROVEEDOR"];
                    purchase.supplier.name = (string)data.Reader["NOMBRE_PROVEEDOR"];
                    purchase.total = (Decimal)data.Reader["TOTAL"];
                    purchase.date = (DateTime)data.Reader["FECHA"];
                    purchase.observations = (string)data.Reader["OBSERVACIONES"];
                    purchase.paymentCondition = (string)data.Reader["CONDICION_PAGO"];
                }

                return purchase;
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
        public List<Purchase> GetAllBySupplier(string cuit)
        {
            List<Purchase> list = new List<Purchase>();

            try
            {
                data.SetQuery("select NUM_COMPRA, COD_PROVEEDOR, P.NOMBRE_PROVEEDOR, TOTAL, C.FECHA FROM COMPRAS C INNER JOIN PROVEEDORES P ON C.COD_PROVEEDOR = P.CUIT where P.CUIT=@CUIT order by NUM_COMPRA desc");
                data.SetParameter("@CUIT",cuit);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Purchase purchase = new Purchase();
                    purchase.supplier = new Supplier();

                    purchase.number = (int)data.Reader["NUM_COMPRA"];
                    purchase.supplier.cuit = (string)data.Reader["COD_PROVEEDOR"];
                    purchase.supplier.name = (string)data.Reader["NOMBRE_PROVEEDOR"];
                    purchase.total = (Decimal)data.Reader["TOTAL"];
                    purchase.date = (DateTime)data.Reader["FECHA"];

                    list.Add(purchase);
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
        public List<Purchase> GetAllByTotalMinimum(decimal min)
        {
            List<Purchase> list = new List<Purchase>();

            try
            {
                data.SetQuery("select NUM_COMPRA, COD_PROVEEDOR, P.NOMBRE_PROVEEDOR, TOTAL, C.FECHA FROM COMPRAS C INNER JOIN PROVEEDORES P ON C.COD_PROVEEDOR = P.CUIT where total >= @min");
                data.SetParameter("@min", min);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Purchase product = new Purchase();
                    product.supplier = new Supplier();

                    product.number = (int)data.Reader["NUM_COMPRA"];
                    product.supplier.cuit = (string)data.Reader["COD_PROVEEDOR"];
                    product.supplier.name = (string)data.Reader["NOMBRE_PROVEEDOR"];
                    product.total = (Decimal)data.Reader["TOTAL"];
                    product.date = (DateTime)data.Reader["FECHA"];

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
        public List<Purchase> GetAllByTotalMaximum(decimal max)
        {
            List<Purchase> list = new List<Purchase>();

            try
            {
                data.SetQuery("select NUM_COMPRA, COD_PROVEEDOR, P.NOMBRE_PROVEEDOR, TOTAL, C.FECHA FROM COMPRAS C INNER JOIN PROVEEDORES P ON C.COD_PROVEEDOR = P.CUIT where total <= @max");
                data.SetParameter("@max", max);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Purchase product = new Purchase();
                    product.supplier = new Supplier();

                    product.number = (int)data.Reader["NUM_COMPRA"];
                    product.supplier.cuit = (string)data.Reader["COD_PROVEEDOR"];
                    product.supplier.name = (string)data.Reader["NOMBRE_PROVEEDOR"];
                    product.total = (Decimal)data.Reader["TOTAL"];
                    product.date = (DateTime)data.Reader["FECHA"];

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
        public List<Purchase> GetAllByTotalRange(decimal minTotal, decimal maxTotal)
        {
            List<Purchase> list = new List<Purchase>();

            try
            {
                data.SetQuery("select NUM_COMPRA, COD_PROVEEDOR, P.NOMBRE_PROVEEDOR, TOTAL, C.FECHA FROM COMPRAS C INNER JOIN PROVEEDORES P ON C.COD_PROVEEDOR = P.CUIT where total between @min and @max");
                data.SetParameter("@min", minTotal);
                data.SetParameter("@max", maxTotal);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Purchase purchase = new Purchase();
                    purchase.supplier = new Supplier();

                    purchase.number = (int)data.Reader["NUM_COMPRA"];
                    purchase.supplier.cuit = (string)data.Reader["COD_PROVEEDOR"];
                    purchase.supplier.name = (string)data.Reader["NOMBRE_PROVEEDOR"];
                    purchase.total = (Decimal)data.Reader["TOTAL"];
                    purchase.date = (DateTime)data.Reader["FECHA"];

                    list.Add(purchase);
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
        public void Add(Purchase purchase)
        {
            try
            {
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                data.SetQuery("INSERT INTO COMPRAS (COD_PROVEEDOR,TOTAL,FECHA) VALUES ('" + purchase.supplier.cuit + "','" + purchase.total + "','" + date + "' )");
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
        public void AddDetail(Purchase purchase, ProductCart productCart)
        {
            int num = GetLastPurchaseNumber();
            try
            {
                data.SetQuery("INSERT INTO DETALLE_COMPRA (DETALLE_COMPRA, COD_PRODUCTO, CANTIDAD, PRECIO_COMPRA, OBSERVACIONES, CONDICION_PAGO) VALUES ('" + num + "','" + productCart.code + "','" + productCart.quantity + "','" + productCart.price + "','" + purchase.observations + "','" + purchase.paymentCondition + "' )");
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
        public List<ProductCart> GetProductsFromPurchaseDetail(int detailNumber)
        {
            List<ProductCart> list = new List<ProductCart>();

            try
            {
                data.SetQuery("SELECT P.NOMBRE,D.CANTIDAD,D.PRECIO_COMPRA FROM DETALLE_COMPRA D INNER JOIN PRODUCTOS P ON D.COD_PRODUCTO = P.CODIGO WHERE DETALLE_COMPRA = @BUSCADO");
                data.SetParameter("@BUSCADO", detailNumber);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    ProductCart aux = new ProductCart();
                    aux.name = (string)data.Reader["NOMBRE"];
                    aux.quantity = (int)data.Reader["CANTIDAD"];
                    aux.price = (decimal)data.Reader["PRECIO_COMPRA"];

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
        public int GetLastPurchaseNumber()
        {
            try
            {
                data.SetQuery("SELECT NUM_COMPRA FROM COMPRAS WHERE NUM_COMPRA = (SELECT max(NUM_COMPRA) FROM COMPRAS)");
                data.ExecuteReader();

                int num = 1;
                while (data.Reader.Read())
                {
                    num = (int)data.Reader["NUM_COMPRA"];
                }

                return num;
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
        public void AddStock(ProductCart productCart)
        {
            //buscar el producto con el id del agregado y obtener el stock
            ProductController controller = new ProductController();
            List<Product> list = controller.GetAll();
            Product product = list.Find(x => x.code == productCart.code);

            try
            {
                data.SetQuery("UPDATE PRODUCTOS SET STOCK_ACTUAL = @STOCK WHERE CODIGO = @CODIGO;");
                data.SetParameter("@STOCK", product.currentStock + productCart.quantity);
                data.SetParameter("@CODIGO", productCart.code);
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
        public void SetPrice(ProductCart productCart)
        {
            try
            {
                data.SetQuery("UPDATE PRODUCTOS SET PRECIO = @PRECIO WHERE CODIGO = @CODIGO;");
                data.SetParameter("@PRECIO", productCart.price);
                data.SetParameter("@CODIGO", productCart.code);
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
        public void SetSalesPrice(ProductCart productCart)
        {
            //buscar el producto con el id del agregado y obtener el porcentaje
            ProductController controller = new ProductController();
            List<Product> list = controller.GetAll();
            Product product = list.Find(x => x.code == productCart.code);

            try
            {
                data.SetQuery("UPDATE PRODUCTOS SET PRECIO_VENTA = @PRECIOVENTA WHERE CODIGO = @CODIGO;");
                data.SetParameter("@PRECIOVENTA", productCart.price + (productCart.price * (product.percentageOfProfit / 100)));
                data.SetParameter("@CODIGO", productCart.code);
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
        public bool ExistProductInPurchase(string productCode)
        {
            try
            {
                data.SetQuery("select COD_PRODUCTO from DETALLE_COMPRA WHERE COD_PRODUCTO=@BUSCADO");
                data.SetParameter("@BUSCADO", productCode);
                data.ExecuteReader();

                return data.Reader.Read();
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
        public decimal GetTotalSumPurchases()
        {
            try
            {
                data.SetQuery("select total from compras");
                data.ExecuteReader();

                decimal total = 0;
                if (data.Reader.Read())
                {
                    data.Close();

                    data.SetQuery("select SUM(total) AS TOTAL from compras");
                    data.ExecuteReader();
                    while (data.Reader.Read())
                    {
                        total = (decimal)data.Reader["TOTAL"];
                    }
                }
                return total;
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
