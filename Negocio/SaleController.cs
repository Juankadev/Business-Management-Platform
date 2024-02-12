using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;
using System.Web;

namespace Negocio
{
    public class SaleController
    {
        DataAccess data = new DataAccess();
        public List<Sale> GetAll()
        {
            List<Sale> list = new List<Sale>();

            try
            {
                data.SetQuery("select V.NUM_VENTA, V.COD_CLIENTE, CL.APELLIDO, V.TOTAL, V.FECHA FROM VENTAS V INNER JOIN CLIENTES CL ON V.COD_CLIENTE = CL.DNI order by V.NUM_VENTA desc");
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Sale sale = new Sale();
                    sale.customer = new Customer();

                    sale.number = (int)data.Reader["NUM_VENTA"];
                    sale.customer.id = (string)data.Reader["COD_CLIENTE"];
                    sale.customer.lastName = (string)data.Reader["APELLIDO"];
                    sale.total = (Decimal)data.Reader["TOTAL"];
                    sale.date = (DateTime)data.Reader["FECHA"];

                    list.Add(sale);
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
        public Sale GetByNumber(int number)
        {
            try
            {
                data.SetQuery("select V.NUM_VENTA, V.COD_CLIENTE, C.APELLIDO + ' ' + C.NOMBRE AS APENOM, V.TOTAL, V.FECHA, VD.OBSERVACIONES, VD.CONDICION_PAGO FROM VENTAS V INNER JOIN CLIENTES C ON C.DNI = V.COD_CLIENTE INNER JOIN DETALLE_VENTA VD ON VD.DETALLE_VENTA = V.NUM_VENTA WHERE V.NUM_VENTA = @BUSCADO");
                data.SetParameter("@BUSCADO", number);
                data.ExecuteReader();

                Sale sale = new Sale();
                sale.customer = new Customer();

                while (data.Reader.Read())
                {
                    sale.number = (int)data.Reader["NUM_VENTA"];
                    sale.customer.id = (string)data.Reader["COD_CLIENTE"];
                    sale.customer.name = (string)data.Reader["APENOM"];
                    sale.total = (Decimal)data.Reader["TOTAL"];
                    sale.date = (DateTime)data.Reader["FECHA"];
                    sale.observations = (string)data.Reader["OBSERVACIONES"];
                    sale.paymentCondition = (string)data.Reader["CONDICION_PAGO"];
                }
                return sale;
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
        public List<Sale> GetByCustomer(string id)
        {
            List<Sale> list = new List<Sale>();

            try
            {
                data.SetQuery("select V.NUM_VENTA, V.COD_CLIENTE, CL.APELLIDO, V.TOTAL, V.FECHA FROM VENTAS V INNER JOIN CLIENTES CL ON V.COD_CLIENTE = CL.DNI WHERE CL.DNI = @DNI order by V.NUM_VENTA desc");
                data.SetParameter("@DNI", id);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Sale aux = new Sale();
                    aux.customer = new Customer();

                    aux.number = (int)data.Reader["NUM_VENTA"];
                    aux.customer.id = (string)data.Reader["COD_CLIENTE"];
                    aux.customer.lastName = (string)data.Reader["APELLIDO"];
                    aux.total = (Decimal)data.Reader["TOTAL"];
                    aux.date = (DateTime)data.Reader["FECHA"];

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
        public List<Sale> GetByMinimumTotal(decimal minimumTotal)
        {
            List<Sale> list = new List<Sale>();

            try
            {
                data.SetQuery("select V.NUM_VENTA, V.COD_CLIENTE, CL.APELLIDO, V.TOTAL, V.FECHA FROM VENTAS V INNER JOIN CLIENTES CL ON V.COD_CLIENTE = CL.DNI where total >= @min");
                data.SetParameter("@min", minimumTotal);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Sale sale = new Sale();
                    sale.customer = new Customer();

                    sale.number = (int)data.Reader["NUM_VENTA"];
                    sale.customer.id = (string)data.Reader["COD_CLIENTE"];
                    sale.customer.lastName = (string)data.Reader["APELLIDO"];
                    sale.total = (Decimal)data.Reader["TOTAL"];
                    sale.date = (DateTime)data.Reader["FECHA"];

                    list.Add(sale);
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
        public List<Sale> GetByMaximumTotal(decimal maximunTotal)
        {
            List<Sale> list = new List<Sale>();

            try
            {
                data.SetQuery("select V.NUM_VENTA, V.COD_CLIENTE, CL.APELLIDO, V.TOTAL, V.FECHA FROM VENTAS V INNER JOIN CLIENTES CL ON V.COD_CLIENTE = CL.DNI where total <= @max");
                data.SetParameter("@max", maximunTotal);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Sale sale = new Sale();
                    sale.customer = new Customer();

                    sale.number = (int)data.Reader["NUM_VENTA"];
                    sale.customer.id = (string)data.Reader["COD_CLIENTE"];
                    sale.customer.lastName = (string)data.Reader["APELLIDO"];
                    sale.total = (Decimal)data.Reader["TOTAL"];
                    sale.date = (DateTime)data.Reader["FECHA"];

                    list.Add(sale);
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
        public List<Sale> GetAllByTotalRange(decimal minTotal, decimal maxTotal)
        {
            List<Sale> list = new List<Sale>();

            try
            {
                data.SetQuery("select V.NUM_VENTA, V.COD_CLIENTE, CL.APELLIDO, V.TOTAL, V.FECHA FROM VENTAS V INNER JOIN CLIENTES CL ON V.COD_CLIENTE = CL.DNI where total between @min and @max");
                data.SetParameter("@min", minTotal);
                data.SetParameter("@max", maxTotal);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Sale sale = new Sale();
                    sale.customer = new Customer();

                    sale.number = (int)data.Reader["NUM_VENTA"];
                    sale.customer.id = (string)data.Reader["COD_CLIENTE"];
                    sale.customer.lastName = (string)data.Reader["APELLIDO"];
                    sale.total = (Decimal)data.Reader["TOTAL"];
                    sale.date = (DateTime)data.Reader["FECHA"];

                    list.Add(sale);
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
        public void Add(Sale sale)
        {
            try
            {
                string prueba = DateTime.Now.ToString("yyyy-MM-dd");
                data.SetQuery("INSERT INTO VENTAS (COD_CLIENTE,TOTAL,FECHA) VALUES ('" + sale.customer.id + "','" + sale.total + "','" + prueba + "' )");
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
        public void AddDetail(Sale sale, ProductCart productCart)
        {
            int lastNumber = GetLastSaleNumber();
            try
            {
                data.SetQuery("INSERT INTO DETALLE_VENTA (DETALLE_VENTA, COD_PRODUCTO, CANTIDAD, PRECIO_VENTA, OBSERVACIONES, CONDICION_PAGO) VALUES ('" + lastNumber + "','" + productCart.code + "','" + productCart.quantity + "','" + productCart.price + "','" + sale.observations + "','" + sale.paymentCondition + "' )");
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
        public int GetLastSaleNumber()
        {
            try
            {
                data.SetQuery("SELECT NUM_VENTA FROM VENTAS WHERE NUM_VENTA = (SELECT max(NUM_VENTA) FROM VENTAS)");
                data.ExecuteReader();

                int number = 1;
                while (data.Reader.Read())
                {
                    number = (int)data.Reader["NUM_VENTA"];
                }

                return number;
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
        public void discountStock(ProductCart productCart)
        {
            //buscar el producto con el id del agregado y obtener el stock
            ProductController controller = new ProductController();
            List<Product> list = controller.GetAll();
            Product product = list.Find(x => x.code == productCart.code);

            try
            {
                data.SetQuery("UPDATE PRODUCTOS SET STOCK_ACTUAL = @STOCK WHERE CODIGO = @CODIGO;");
                data.SetParameter("@STOCK", product.currentStock - productCart.quantity);
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
        public List<ProductCart> GetProductsFromPurchaseDetail(int detailNumber)
        {
            List<ProductCart> list = new List<ProductCart>();

            try
            {
                data.SetQuery("SELECT P.NOMBRE, D.CANTIDAD, D.PRECIO_VENTA FROM DETALLE_VENTA D INNER JOIN PRODUCTOS P ON D.COD_PRODUCTO = P.CODIGO WHERE DETALLE_VENTA = @BUSCADO");
                data.SetParameter("@BUSCADO", detailNumber);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    ProductCart aux = new ProductCart();
                    aux.name = (string)data.Reader["NOMBRE"];
                    aux.quantity = (int)data.Reader["CANTIDAD"];
                    aux.price = (decimal)data.Reader["PRECIO_VENTA"];

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
        public decimal GetTotalSumSales()
        {
            try
            {
                data.SetQuery("select total from ventas");
                data.ExecuteReader();
                decimal total = 0;

                if (data.Reader.Read())
                {
                    data.Close();

                    data.SetQuery("select SUM(total) AS TOTAL from ventas");
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
        public decimal GetAverageOfTotalSales()
        {
            try
            {
                data.SetQuery("select total from ventas");
                data.ExecuteReader();
                decimal total = 0;

                if (data.Reader.Read())
                {
                    data.Close();

                    data.SetQuery("select AVG(total) AS TOTAL from ventas");
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
