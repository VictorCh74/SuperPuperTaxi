using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SuperPuperTaxi.Models;


namespace SuperPuperTaxi.Controllers
{
    

    public class AddDriverController : Controller
    {
        private IDriverRepository db;
        public bool dbAccesed;

        public AddDriverController(IDriverRepository context) {
            this.db = context;
        }


        public IActionResult AddDriver()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNewDriver(TaxiDriver driver)
        {
            dbAccesed = db.Add(driver);
            await db.Save();
            return RedirectToAction("AddDriver");
        }

    }


}