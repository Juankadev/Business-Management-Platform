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
        public _Marca IDMarca { get; set; }
        public _Categoria IDCategoria { get; set; }
        public _Proveedor2 CUITProveedor { get; set; }
        public decimal Precio { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public int PorcentajeGanancia { get; set; }

    }
}
