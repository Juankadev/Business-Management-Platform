
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dominio;

namespace Negocio
{
    public class SupplierController
    {
        public List<Supplier> GetAll()
        {
            List<Supplier> list = new List<Supplier>();
            DataAccess data = new DataAccess();

            try
            {
                data.SetQuery("select CUIT,NOMBRE_PROVEEDOR,TELEFONO,MAIL,DIRECCION FROM PROVEEDORES WHERE ACTIVO=1 ORDER BY NOMBRE_PROVEEDOR ASC");
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Supplier aux = new Supplier();
                    aux.cuit = (string)data.Reader["CUIT"];
                    aux.name = (string)data.Reader["NOMBRE_PROVEEDOR"];
                    aux.phone = (string)data.Reader["TELEFONO"];
                    aux.email = (string)data.Reader["MAIL"];
                    aux.address = (string)data.Reader["DIRECCION"];

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
        public List<Supplier> GetAllByPartialDescription(string description)
        {
            List<Supplier> list = new List<Supplier>();
            DataAccess data = new DataAccess();

            try
            {
                data.SetQuery("select CUIT,NOMBRE_PROVEEDOR,TELEFONO,MAIL,DIRECCION FROM PROVEEDORES WHERE ACTIVO=1 AND NOMBRE_PROVEEDOR LIKE CONCAT('%',@TEXTO,'%') ");
                data.SetParameter("@TEXTO", description);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Supplier aux = new Supplier();
                    aux.cuit = (string)data.Reader["CUIT"];
                    aux.name = (string)data.Reader["NOMBRE_PROVEEDOR"];
                    aux.phone = (string)data.Reader["TELEFONO"];
                    aux.email = (string)data.Reader["MAIL"];
                    aux.address = (string)data.Reader["DIRECCION"];

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
        public void Add(Supplier supplier)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.SetQuery("INSERT INTO PROVEEDORES (CUIT,NOMBRE_PROVEEDOR,TELEFONO,MAIL,DIRECCION, ACTIVO) VALUES ('" + supplier.cuit + "','" + supplier.name + "','" + supplier.phone + "','" + supplier.email + "','" + supplier.address + "','" + 1 + "' )");
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
        public void Modify(Supplier supplier)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.SetQuery("UPDATE PROVEEDORES SET CUIT=@CUIT,NOMBRE_PROVEEDOR=@NOMBRE,TELEFONO=@TELEFONO,MAIL=@MAIL,DIRECCION=@DIRECCION WHERE CUIT=@CUIT");
                data.SetParameter("@CUIT", supplier.cuit);
                data.SetParameter("@NOMBRE", supplier.name);
                data.SetParameter("@TELEFONO", supplier.phone);
                data.SetParameter("@MAIL", supplier.email);
                data.SetParameter("@DIRECCION", supplier.address);

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
        public void Delete(string cuit)
        {
            DataAccess datos = new DataAccess();
            try
            {
                datos.SetQuery("UPDATE PROVEEDORES SET ACTIVO = 0 WHERE CUIT = @CUIT");
                datos.SetParameter("@CUIT", cuit);
                datos.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.Close();
            }
        }
        public List<String> GetAssociatedSuppliers(string productCode)
        {
            List<String> list = new List<String>();
            DataAccess data = new DataAccess();

            try
            {
                data.SetQuery("select P.NOMBRE_PROVEEDOR FROM PROVEEDORES AS P INNER JOIN PROVEEDORES_X_PRODUCTO PXP ON P.CUIT = PXP.CUIT_PROVEEDOR INNER JOIN PRODUCTOS AS PR ON PR.CODIGO = PXP.CODIGO_PRODUCTO WHERE PR.CODIGO = @BUSCADO");
                data.SetParameter("@BUSCADO", productCode);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    string aux = (string)data.Reader["NOMBRE_PROVEEDOR"];
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
        public List<String> GetAllNames()
        {
            List<String> list = new List<String>();
            DataAccess data = new DataAccess();

            try
            {
                data.SetQuery("select NOMBRE_PROVEEDOR FROM PROVEEDORES WHERE ACTIVO=1");
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    string aux = (string)data.Reader["NOMBRE_PROVEEDOR"];
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
        public void DeleteAssociatedSuppliers(string cuit, string productCode)
        {
            DataAccess data = new DataAccess();
            try
            {
                data.SetQuery("DELETE FROM PROVEEDORES_X_PRODUCTO WHERE CUIT_PROVEEDOR=@CUIT AND CODIGO_PRODUCTO=@CODIGO");
                data.SetParameter("@CUIT", cuit);
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
    }
}
