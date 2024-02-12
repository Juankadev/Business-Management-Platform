using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CustomerController
    {
        DataAccess data = new DataAccess();
        public List<Customer> GetAll()
        {
            List<Customer> list = new List<Customer>();

            try
            {
                data.SetQuery("select DNI,APELLIDO,NOMBRE,TELEFONO,MAIL,DIRECCION FROM CLIENTES WHERE ACTIVO=1 order by APELLIDO asc");
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Customer customer = new Customer();
   
                    customer.id = (string)data.Reader["DNI"];
                    customer.lastName = (string)data.Reader["APELLIDO"];
                    customer.name = (string)data.Reader["NOMBRE"];
                    customer.phone = (string)data.Reader["TELEFONO"];
                    customer.email = (string)data.Reader["MAIL"];
                    customer.address = (string)data.Reader["DIRECCION"];

                    list.Add(customer);
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
        public List<Customer> GetAllByPartialLastName(string lastName)
        {
            List<Customer> list = new List<Customer>();

            try
            {
                data.SetQuery("select DNI,APELLIDO,NOMBRE,TELEFONO,MAIL,DIRECCION FROM CLIENTES WHERE ACTIVO=1 AND APELLIDO LIKE CONCAT('%',@TEXTO,'%')");
                data.SetParameter("@TEXTO", lastName);
                data.ExecuteReader();

                while (data.Reader.Read())
                {
                    Customer aux = new Customer();

                    aux.id = (string)data.Reader["DNI"];
                    aux.lastName = (string)data.Reader["APELLIDO"];
                    aux.name = (string)data.Reader["NOMBRE"];
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
        public void Add(Customer customer)
        {
            try
            {
                data.SetQuery("INSERT INTO CLIENTES (DNI,APELLIDO,NOMBRE,TELEFONO,MAIL,DIRECCION,ACTIVO) VALUES ('" + customer.id + "','" + customer.lastName + "','" + customer.name + "','" + customer.phone + "','" + customer.email + "','" + customer.address + "','" + 1 + "' )");
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
        public void Modify(Customer customer)
        {
            try
            {
                data.SetQuery("UPDATE CLIENTES SET DNI=@DNI,NOMBRE=@NOMBRE,APELLIDO=@APELLIDO,TELEFONO=@TELEFONO,MAIL=@MAIL,DIRECCION=@DIRECCION WHERE DNI=@DNI");
                data.SetParameter("@DNI", customer.id);
                data.SetParameter("@NOMBRE", customer.name);
                data.SetParameter("@APELLIDO", customer.lastName);
                data.SetParameter("@TELEFONO", customer.phone);
                data.SetParameter("@MAIL", customer.email);
                data.SetParameter("@DIRECCION", customer.address);

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
        public void Delete(string id)
        {
            try
            {
                data.SetQuery("UPDATE CLIENTES SET ACTIVO = 0 WHERE DNI = @DNI");
                data.SetParameter("@DNI", id);
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
