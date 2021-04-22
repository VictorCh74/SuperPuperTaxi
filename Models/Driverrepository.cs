using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SuperPuperTaxi.Models
{
    public class DriverRepository : IDriverRepository
    {
        private ApplicationContext db;

        public DriverRepository(DbContextOptions<ApplicationContext> option)
        {
            this.db = new ApplicationContext(option);
        }



        public virtual List<TaxiDriver> GetDriverList() {
            return db.TaxiDrivers.ToList();
        }

        public TaxiDriver GetDriverItem(int id) {
            return db.TaxiDrivers.Find(id); 
        }

        public bool Add(TaxiDriver item) {
            if (db.TaxiDrivers.Add(item).Entity == item)
                return true;
            return false;
        }

        public void Update(Object item) {
            db.Entry(item).State = EntityState.Modified;
        }

        public bool Delete(int id) {
            var before = db.TaxiDrivers.Count<TaxiDriver>();
            db.TaxiDrivers.Remove(GetDriverItem(id));
            if (before > db.TaxiDrivers.Count<TaxiDriver>())
                return true;
            return false;
        }

        public async Task<int> Save()
        {
            return db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
