using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class CompraNegocio
    {

        public List<_Compra> listar()
        {
            List<_Compra> lista = new List<_Compra>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select NUM_COMPRA, COD_PROVEEDOR, P.NOMBRE_PROVEEDOR, TOTAL, FECHA FROM COMPRAS C INNER JOIN PROVEEDORES P ON C.COD_PROVEEDOR = P.CUIT");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Compra aux = new _Compra();
                    aux.Proveedor = new _Proveedor2();

                    aux.numcompra = (int)datos.Lector["NUM_COMPRA"];
                    aux.Proveedor.CUIT = (string)datos.Lector["COD_PROVEEDOR"];
                    aux.Proveedor.Nombre = (string)datos.Lector["NOMBRE_PROVEEDOR"];
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


        public void agregar(_Compra nuevaCompra)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("INSERT INTO COMPRAS (COD_PROVEEDOR,TOTAL,FECHA) VALUES ('" + nuevaCompra.Proveedor.CUIT + "','" + nuevaCompra.Total + "','" + "1900-01-01 00:00:00" + "' )");
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
