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

        public _Venta listarxnum(int buscado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("select V.NUM_VENTA, V.COD_CLIENTE, C.APELLIDO + ' ' + C.NOMBRE AS APENOM, V.TOTAL, V.FECHA, VD.OBSERVACIONES, VD.CONDICION_PAGO FROM VENTAS V INNER JOIN CLIENTES C ON C.DNI = V.COD_CLIENTE INNER JOIN DETALLE_VENTA VD ON VD.DETALLE_VENTA = V.NUM_VENTA WHERE V.NUM_VENTA = @BUSCADO");
                datos.setearParametro("@BUSCADO", buscado);
                datos.ejecutarLectura();

                _Venta aux = new _Venta();
                aux.Cliente = new _Cliente();

                while (datos.Lector.Read())
                {
                    aux.numventa = (int)datos.Lector["NUM_VENTA"];
                    aux.Cliente.DNI = (string)datos.Lector["COD_CLIENTE"];
                    aux.Cliente.Nombre = (string)datos.Lector["APENOM"];
                    aux.Total = (Decimal)datos.Lector["TOTAL"];
                    aux.Fecha = (DateTime)datos.Lector["FECHA"];
                    aux.Observaciones = (string)datos.Lector["OBSERVACIONES"];
                    aux.Condicion = (string)datos.Lector["CONDICION_PAGO"];
                }

                return aux;
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

        public List<_Venta> listarxcliente(string dni)
        {
            List<_Venta> lista = new List<_Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select V.NUM_VENTA, V.COD_CLIENTE, CL.APELLIDO, V.TOTAL, V.FECHA FROM VENTAS V INNER JOIN CLIENTES CL ON V.COD_CLIENTE = CL.DNI WHERE CL.DNI = @DNI order by V.NUM_VENTA desc");
                datos.setearParametro("@DNI", dni);
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


        public List<_Venta> listarxmin(decimal min)
        {
            List<_Venta> lista = new List<_Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select V.NUM_VENTA, V.COD_CLIENTE, CL.APELLIDO, V.TOTAL, V.FECHA FROM VENTAS V INNER JOIN CLIENTES CL ON V.COD_CLIENTE = CL.DNI where total >= @min");
                datos.setearParametro("@min", min);
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

        public List<_Venta> listarxmax(decimal max)
        {
            List<_Venta> lista = new List<_Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select V.NUM_VENTA, V.COD_CLIENTE, CL.APELLIDO, V.TOTAL, V.FECHA FROM VENTAS V INNER JOIN CLIENTES CL ON V.COD_CLIENTE = CL.DNI where total <= @max");
                datos.setearParametro("@max", max);
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

        public List<_Venta> listarxrango(decimal min, decimal max)
        {
            List<_Venta> lista = new List<_Venta>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select V.NUM_VENTA, V.COD_CLIENTE, CL.APELLIDO, V.TOTAL, V.FECHA FROM VENTAS V INNER JOIN CLIENTES CL ON V.COD_CLIENTE = CL.DNI where total between @min and @max");
                datos.setearParametro("@min", min);
                datos.setearParametro("@max", max);
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

        public List<Agregados> listarDetalleProducto(int buscado)
        {
            List<Agregados> lista = new List<Agregados>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT P.NOMBRE, D.CANTIDAD, D.PRECIO_VENTA FROM DETALLE_VENTA D INNER JOIN PRODUCTOS P ON D.COD_PRODUCTO = P.CODIGO WHERE DETALLE_VENTA = @BUSCADO");
                datos.setearParametro("@BUSCADO", buscado);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Agregados aux = new Agregados();
                    //aux.Proveedor = new _Proveedor2();

                    aux.Nombre = (string)datos.Lector["NOMBRE"];
                    aux.Cantidad = (int)datos.Lector["CANTIDAD"];
                    aux.Precio = (decimal)datos.Lector["PRECIO_VENTA"];

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


        public decimal total()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //ver si hay registros
                datos.setearConsulta("select total from ventas");
                datos.ejecutarLectura();
                decimal total = 0;

                if (datos.Lector.Read())
                {
                    datos.cerrarConexion();

                    datos.setearConsulta("select SUM(total) AS TOTAL from ventas");
                    datos.ejecutarLectura();
                    while (datos.Lector.Read())
                    {
                        total = (decimal)datos.Lector["TOTAL"];
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
                datos.cerrarConexion();
            }

        }



        public decimal promedio()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //ver si hay registros
                datos.setearConsulta("select total from ventas");
                datos.ejecutarLectura();
                decimal total = 0;

                if (datos.Lector.Read())
                {
                    datos.cerrarConexion();

                    datos.setearConsulta("select AVG(total) AS TOTAL from ventas");
                    datos.ejecutarLectura();
                    while (datos.Lector.Read())
                    {
                        total = (decimal)datos.Lector["TOTAL"];
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
                datos.cerrarConexion();
            }

        }

    }
}
