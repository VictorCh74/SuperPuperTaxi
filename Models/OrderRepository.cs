using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SuperPuperTaxi.Models
{
    public class OrderRepository : IRepository  
    {
        private ApplicationContext db;

        public OrderRepository(DbContextOptions<ApplicationContext> option) {
            this.db = new ApplicationContext(option);
        }

        public List<Order> GetOrderList() {
            return db.Orders.ToList();
        }
         
        public List<TaxiDriver> GetDriverList() {
            return db.TaxiDrivers.ToList();
        }

        public Order GetOrderItem(int id) {
            return db.Orders.Find(id);
        }
        public TaxiDriver GetDriverItem(int id)
        {
            return db.TaxiDrivers.Find(id);
        }


        public bool AddOrder(Order item) {
            if(db.Orders.Add(item).Entity == item)
                return true;
            return false;
        }
    
        public void Update(Object item) {
            db.Entry(item).State = EntityState.Modified;
        }

        public bool DeleteOrder(int id) {
            var before = db.Orders.Count<Order>();
            db.Orders.Remove(GetOrderItem(id));
            if (before > db.Orders.Count<Order>())
                return true;
            return false;    
        }


        async public Task<int> Save() {
            return db.SaveChanges();
        }

        public void Dispose() {
            db.Dispose();
        }
    }
}
