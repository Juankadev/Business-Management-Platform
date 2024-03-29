﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class CategoryController
    {
        DataAccess data = new DataAccess();
        public List<Category> GetAll()
        {
            List<Category> list = new List<Category>();

            try
            {
                data.SetQuery("select Id, DESCRIPCION_CATEGORIA FROM CATEGORIAS WHERE ACTIVO=1 order by DESCRIPCION_CATEGORIA asc");
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Category category = new Category();
                    category.id = (int)data.Reader["Id"];
                    category.description = (string)data.Reader["DESCRIPCION_CATEGORIA"];

                    list.Add(category);
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
        public List<Category> GetAllByPartialDescription(string description)
        {
            List<Category> list = new List<Category>();

            try
            {
                data.SetQuery("select Id, DESCRIPCION_CATEGORIA FROM CATEGORIAS WHERE ACTIVO=1 AND DESCRIPCION_CATEGORIA LIKE CONCAT('%',@TEXTO,'%')");
                data.SetParameter("@TEXTO", description);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Category category = new Category();
                    category.id = (int)data.Reader["Id"];
                    category.description = (string)data.Reader["DESCRIPCION_CATEGORIA"];

                    list.Add(category);
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
        public void Add(Category category)
        {
            try
            {
                data.SetQuery("INSERT INTO CATEGORIAS (DESCRIPCION_CATEGORIA, ACTIVO) VALUES ('" + category.description + "','" + 1 + "' )");
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
        public void Modify(Category category)
        {
            try
            {
                data.SetQuery("UPDATE CATEGORIAS SET DESCRIPCION_CATEGORIA=@DESCRIPCION WHERE ID=@ID");
                data.SetParameter("@ID", category.id);
                data.SetParameter("@DESCRIPCION", category.description);

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
                data.SetQuery("UPDATE CATEGORIAS SET ACTIVO = 0 WHERE ID = @ID");
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
