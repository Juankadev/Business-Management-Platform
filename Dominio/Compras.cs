using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Compras
    {
        public int NumCompra { get; set; }
        public _Proveedor2 CodigoProveedor { get; set; }
        public _Producto CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }

    }
}
