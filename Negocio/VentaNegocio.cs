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
    }
}
