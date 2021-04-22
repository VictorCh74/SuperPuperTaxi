using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperPuperTaxi.Models
{
    public class Order
    {
        public int Id { set; get; }
        public DateTime OrderTime { set; get; } 
        public string Phone { set; get; }
        public string From { set; get; }
        public string To { set; get; }
        public string DepartureTime { set ; get; }
        public int Price { set; get; }
        public int TaxiDriverId { set; get; }
    }
}
