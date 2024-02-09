using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Sale
    {
        public int number { get; set; }
        public Customer customer { get; set; }
        public decimal total { get; set; }
        public DateTime date { get; set; }
        public string observations { get; set; }
        public string paymentCondition { get; set; }
    }
}
