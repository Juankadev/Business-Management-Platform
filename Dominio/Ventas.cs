using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Ventas
    {
        public int Venta { get; set; }
        public _Cliente CodigoCliente { get; set; }
        public Decimal Importe { get; set; }
    }
}
