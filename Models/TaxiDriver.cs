using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperPuperTaxi.Models
{
    public class TaxiDriver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string CarStateNumber { get; set; }
        public string CarModel { get; set; }
        public float DaySalary { get; set; }
        public string IsFree { get; set; }
    }
}
