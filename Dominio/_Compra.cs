using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class _Compra
    {
        public int numcompra { get; set; }
        public _Proveedor2 Proveedor { get; set; }
        public decimal Total { get; set; }
        public DateTime Fecha { get; set; }
        public string Observaciones { get; set; }
        public string Condicion { get; set; }

    }
}
