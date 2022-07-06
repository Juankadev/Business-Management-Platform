using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public enum TipoUsuario
    {
        NORMAL = 1,
        ADMIN = 2
    }
    public class _Usuario
    {
        public int IDUsuario { get; set; }
        public string Mail { get; set; }
        public string Contraseña { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        //public int Activo { get; set; }

        public _Usuario(string mail,string pass,bool admin)
        {
            Mail = mail;
            Contraseña = pass;
            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
        }
    }
}
