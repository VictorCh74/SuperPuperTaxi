
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SuperPuperTaxi.Models;



namespace SuperPuperTaxi.Controllers
{
    public class RemoveDriverController : Controller
    {
        IDriverRepository db;

        public RemoveDriverController(IDriverRepository db) {
            this.db = db;
        }

        public IActionResult ShowDrivers()
        {
            ViewBag.Drivers = db.GetDriverList();
            return View();
        }

        [HttpGet]
        public IActionResult RemoveNow(int Id) {
            db.Delete(Id);
            db.Save();
            return RedirectToAction("ShowDrivers");
        }
    }
}