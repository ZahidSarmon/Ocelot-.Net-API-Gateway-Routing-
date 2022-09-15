using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Order.Models
{
    public class ModelOrder
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Unit { get; set; }
        public int Qty { get; set; }
        public decimal TotalAmount { get; set; }
    }
}