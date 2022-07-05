using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class _Venta
    {
        public int numventa { get; set; }
        public _Cliente Cliente { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public string Condicion { get; set; }
    }
}
