using System;
using System.Collections.Generic;
using SuperPuperTaxi.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SuperPuperTaxi.Models
{
    public interface IRepository : IDisposable 
    {
        List<Order> GetOrderList();
        List<TaxiDriver> GetDriverList();

     
        TaxiDriver GetDriverItem(int id);

        bool AddOrder(Order item);
        

        void Update(Object item);

        bool DeleteOrder(int id);
       

        Task<int> Save();
    }
}
