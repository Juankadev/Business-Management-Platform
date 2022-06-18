using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Usuario
    {
        public int IDUsuario { get; set; }
        public string Nombre { get; set; }
        public string Contraseña { get; set; }
        public string TipoUsuario { get; set; }
    }
}
