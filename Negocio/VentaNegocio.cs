using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class VentaNegocio
    {
        public List<_Venta> listar()
        {
            List<_Venta> lista = new List<_Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select V.NUM_VENTA, V.COD_CLIENTE, CL.APELLIDO, V.TOTAL, V.FECHA FROM VENTAS V INNER JOIN CLIENTES CL ON V.COD_CLIENTE = CL.DNI order by V.NUM_VENTA desc");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Venta aux = new _Venta();
                    aux.Cliente = new _Cliente();

                    aux.numventa = (int)datos.Lector["NUM_VENTA"];
                    aux.Cliente.DNI = (string)datos.Lector["COD_CLIENTE"];
                    aux.Cliente.Apellido = (string)datos.Lector["APELLIDO"];
                    aux.Total = (Decimal)datos.Lector["TOTAL"];
                    aux.Fecha = (DateTime)datos.Lector["FECHA"];

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

        public void agregar(_Venta nuevaVenta)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO VENTAS (COD_CLIENTE,TOTAL,FECHA) VALUES ('" + nuevaVenta.Cliente.DNI + "','" + nuevaVenta.Total + "','" + nuevaVenta.Fecha + "' )");
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

        public void agregarDetalle(_Venta nuevaVenta, Agregados agregado)
        {
            AccesoDatos datos = new AccesoDatos();
            int num = ultimoNumVenta();
            try
            {
                datos.setearConsulta("INSERT INTO DETALLE_VENTA (DETALLE_VENTA, COD_PRODUCTO, CANTIDAD, PRECIO_VENTA, OBSERVACIONES, CONDICION_PAGO) VALUES ('" + num + "','" + agregado.Codigo + "','" + agregado.Cantidad + "','" + agregado.Precio + "','" + nuevaVenta.Observaciones + "','" + nuevaVenta.Condicion + "' )");
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

        public int ultimoNumVenta()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT NUM_VENTA FROM VENTAS WHERE NUM_VENTA = (SELECT max(NUM_VENTA) FROM VENTAS)");
                datos.ejecutarLectura();

                int num = 1;
                while (datos.Lector.Read())
                {

                    num = (int)datos.Lector["NUM_VENTA"];
                }

                return num;
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


        public void descontarStock(Agregados agregado)
        {
            AccesoDatos datos = new AccesoDatos();

            //buscar el producto con el id del agregado y obtener el stock
            ProductoNegocio negocio = new ProductoNegocio();
            List<_Producto> lista = negocio.listar();
            _Producto producto = lista.Find(x => x.Codigo == agregado.Codigo);

            try
            {
                datos.setearConsulta("UPDATE PRODUCTOS SET STOCK_ACTUAL = @STOCK WHERE CODIGO = @CODIGO;");
 
                datos.setearParametro("@STOCK", producto.StockActual - agregado.Cantidad);
                datos.setearParametro("@CODIGO", agregado.Codigo);
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


    }
}
