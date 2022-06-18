using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Proveedor
    {
        public string CUIT { get; set; }
        public string Apellido { get; set; }
        public string Nombre { get; set; }
        public string Telefono { get; set; }
        public string Mail { get; set; }
        public string Direccion { get; set; }
        public Localidad Codigo_Postal { get; set; }
    }
}
