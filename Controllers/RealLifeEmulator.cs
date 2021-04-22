using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperPuperTaxi.Models;
using Microsoft.EntityFrameworkCore;

namespace SuperPuperTaxi.Controllers
{
    public class RealLifeEmulator
    {
        IDriverRepository db;
        
        public RealLifeEmulator(IDriverRepository context) {
            this.db = context;
        }

     

        int SetNumberToFree() {
            var rand = new Random();
            
            return rand.Next(db.GetDriverList().Where(d => d.IsFree == "IsBusy").Count<TaxiDriver>()); 
        }

        public int FreeTaxiDriver() {
            int freeCount = 0;

            if (SetNumberToFree() == 0) return -1;

            foreach (TaxiDriver t in db.GetDriverList().Where(d => d.IsFree == "IsBusy").
                Take(SetNumberToFree()))
            {
                t.IsFree = "IsFree";
                freeCount++;
            }

            db.Save();
            return freeCount;
        }
    }
}
