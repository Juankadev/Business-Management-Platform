using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    class Compra
    {
        public int NumCompra { get; set; }
        public Proveedor CodigoProveedor { get; set; }
        public Producto CodigoProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
    }
}
