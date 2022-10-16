using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Editing;
using System.Diagnostics;
using TT.ASC.APP.Models;

namespace TT.ASC.APP.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
         
            return View();
        }

        [HttpGet]
        public IActionResult Bai1()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Bai1(FormCollection cl)
        {
            int day = int.Parse(cl["day"].ToString());
            int month = int.Parse(cl["month"].ToString());
            int year = int.Parse(cl["year"].ToString());
            int hours = int.Parse(cl["hours"].ToString());
            int minute = int.Parse(cl["minute"].ToString());
            int second = int.Parse(cl["second"].ToString());
            DateTime myDate = BaiTapASC.FormatDateTime(year, month, day, hours, minute, second);

            ViewBag.myDate = myDate;
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}