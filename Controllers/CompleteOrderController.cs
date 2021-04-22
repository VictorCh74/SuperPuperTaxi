using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq; 
using SuperPuperTaxi.Models;
using System.Threading.Tasks;

namespace SuperPuperTaxi.Controllers
{
    public class CompleteOrder : Controller
    {
        
        IRepository rep;


        public CompleteOrder(IRepository r)
        {
            rep = r;
   
        }
     
        public IActionResult Accept(Order order)
        {
            return View(order);
        }

        [HttpPost] 
        async public Task<IActionResult> RecordOrder(Order order) {
            RegisterOrder(order);
            await rep.Save();
            return RedirectToAction("Accept" , order);
        }

        void RegisterOrder(Order order) {
            ActivateTaxi(order, rep);
            order.OrderTime = DateTime.Now;
            rep.AddOrder(order);
        }

        string ActivateTaxi(Order order, IRepository rep)
        {
             
            var drivers = rep.GetDriverList().Where(a => a.IsFree == "IsFree");

            var num = drivers.ToArray<TaxiDriver>().Length;
            
            order.TaxiDriverId = drivers.ToArray<TaxiDriver>()[ new Random().Next(num) ].Id;
            return rep.GetDriverList().Where<TaxiDriver>(x => x.Id == order.TaxiDriverId).
                    First<TaxiDriver>().IsFree = "IsBusy";
        }
    }
}
