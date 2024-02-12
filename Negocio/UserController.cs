using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UserController
    {
        DataAccess data = new DataAccess();
        public bool Login(User user)
        {
            try
            {
                data.SetQuery("select ID_USUARIO, tipo_usuario from usuarios where mail = @mail and contraseña = @contraseña");
                data.SetParameter("@mail",user.email);
                data.SetParameter("@contraseña", user.password);
                data.ExecuteReader();

                while(data.Reader.Read())
                {
                    user.id = (int)data.Reader["ID_USUARIO"];
                    user.userType = (int)data.Reader["tipo_usuario"] == 2 ? UserTypes.ADMIN : UserTypes.CLIENT;
                    return true;
                }
                return false;
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
