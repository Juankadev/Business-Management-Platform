using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;
using Negocio;

namespace Negocio
{
    public class MarcaNegocio
    {
        public List<_Marca> listar()
        {
            List<_Marca> lista = new List<_Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("select Id, Descripcion FROM MARCAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    _Marca aux = new _Marca();
                    aux.IDMarca = (int)datos.Lector["Id"];
                    aux.DescripcionMarca = (string)datos.Lector["Descripcion"];

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
