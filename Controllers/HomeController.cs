using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using SuperPuperTaxi.Models;

namespace SuperPuperTaxi.Controllers
{
    public class    HomeController : Controller
    {
       
        private ApplicationContext db;

        public HomeController(ApplicationContext context)
        {
            
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MakeOrder()
        {
            
            return View();
    
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
