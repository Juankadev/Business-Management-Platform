using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class _Producto
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public _Marca Marca { get; set; }
        public _Categoria Categoria { get; set; }
        //public _Proveedor2 Proveedor { get; set; }
        public decimal Precio { get; set; }
        public decimal StockActual { get; set; }
        public decimal StockMinimo { get; set; }
        public decimal PorcentajeGanancia { get; set; }

    }
}
