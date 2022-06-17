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
        public Proveedores CodigoProveedor { get; set; }
        public Productos CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }

    }
}
