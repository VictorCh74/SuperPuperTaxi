using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SuperPuperTaxi.Models;

namespace SuperPuperTaxi.Controllers
{
    public class AdminController : Controller
    {
     
        public IActionResult Admin()
        {
            return View();
        }
    }
}
