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
    public class BrandController
    {
        DataAccess data = new DataAccess();
        public List<Brand> GetAll()
        {
            List<Brand> list = new List<Brand>();

            try
            {
                data.SetProcedure("SP_GET_MARCAS");
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Brand brand = new Brand();
                    brand.id = (int)data.Reader["Id"];
                    brand.description = (string)data.Reader["DESCRIPCION_MARCA"];

                    list.Add(brand);
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
        public List<Brand> GetAllByPartialDescription(string description)
        {
            List<Brand> list = new List<Brand>();

            try
            {
                data.SetQuery("select Id, DESCRIPCION_MARCA FROM MARCAS WHERE ACTIVO=1 AND DESCRIPCION_MARCA LIKE CONCAT('%',@TEXTO,'%') ");
                data.SetParameter("@TEXTO", description);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Brand brand = new Brand();
                    brand.id = (int)data.Reader["Id"];
                    brand.description = (string)data.Reader["DESCRIPCION_MARCA"];

                    list.Add(brand);
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
        public void Add(Brand brand)
        {
            try
            {
                data.SetQuery("INSERT INTO MARCAS (DESCRIPCION_MARCA,ACTIVO) VALUES ('" + brand.description + "','" + 1 + "' )");
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
        public void Modify(Brand brand)
        {
            try
            {
                data.SetQuery("UPDATE MARCAS SET DESCRIPCION_MARCA=@DESCRIPCION WHERE ID=@ID");
                data.SetParameter("@ID", brand.id);
                data.SetParameter("@DESCRIPCION", brand.description);

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
        public void Delete(int id)
        {
            try
            {
                data.SetQuery("UPDATE MARCAS SET ACTIVO = 0 WHERE ID = @ID");
                data.SetParameter("@ID", id);
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
    }
}
