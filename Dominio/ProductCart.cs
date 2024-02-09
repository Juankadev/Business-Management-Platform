using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ProductCart
    {
        public string code { get; set; }
        public string name { get; set; }
        public decimal quantity { get; set; }
        public decimal price { get; set; }
    }
}
