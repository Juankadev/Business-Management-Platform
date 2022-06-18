using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Venta
    {
        public int Venta { get; set; }
        public Cliente CodigoCliente { get; set; }
        public Decimal Importe { get; set; }
    }
}
