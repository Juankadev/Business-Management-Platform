using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum UserTypes
    {
        CLIENT = 1,
        ADMIN = 2
    }
    public class User
    {
        public int id { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public UserTypes userType { get; set; }
        //public int active { get; set; }

        public User(string email, string password, UserTypes userType)
        {
            this.email = email;
            this.password = password;
            this.userType = userType;
        }
    }
}
