using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Negocio
{
    public class DataAccess
    {
        private SqlConnection connection;
        private SqlCommand command;
        private SqlDataReader reader;
        public SqlDataReader Reader
        {
            get { return reader; }
        }

        public DataAccess()
        {
            connection = new SqlConnection("server=.\\SQLEXPRESS; database=COMERCIO_DB; integrated security=true");
            //conexion = new SqlConnection();
            //conexion.ConnectionString = "workstation id=COMERCIODB.mssql.somee.com;packet size=4096;user id=juankadev_SQLLogin_1;pwd=5v5f2ikp6m;data source=COMERCIODB.mssql.somee.com;persist security info=False;initial catalog=COMERCIODB";
            command = new SqlCommand();
        }

        public void SetQuery(string query)
        {
            command.CommandType = System.Data.CommandType.Text;
            command.CommandText = query;
        }

        public void SetProcedure(string procedure)
        {
            command.CommandType = System.Data.CommandType.StoredProcedure;
            command.CommandText = procedure;
        }

        public void ExecuteReader()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                reader = command.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void ExecuteNonQuery()
        {
            command.Connection = connection;
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void SetParameter(string parameterName, object value)
        {
            command.Parameters.AddWithValue(parameterName, value);
        }

        public void Close()
        {
            if (reader != null)
                reader.Close();
            connection.Close();
        }
    }
}
