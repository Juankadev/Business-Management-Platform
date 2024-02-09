using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Product
    {
        public string code { get; set; }
        public string name { get; set; }
        public Brand brand { get; set; }
        public Category category { get; set; }
        //public _Proveedor2 Proveedor { get; set; }
        public decimal price { get; set; }
        public decimal PrecioVenta { get; set; }
        public decimal currentStock { get; set; }
        public decimal minimumStock { get; set; }
        public decimal percentageOfProfit { get; set; }

    }
}
