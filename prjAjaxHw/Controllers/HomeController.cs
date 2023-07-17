using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using prjAjaxHw.Models;
using System.Diagnostics;
using System.Net;

namespace prjAjaxHw.Controllers
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

        public IActionResult Hw1()
        {
            return View();
        }
        public IActionResult Hw2()
        {
            return View();
        }
        public IActionResult Hw3()
        {
            return View();
        }

        public IActionResult Hw4()
        {
            return View();
        }
        public IActionResult Hw5() {
            return View();
        }
        public IActionResult Hw6() {
            return View();
        }
        public IActionResult Hw7() {
            return View();
        }


        public IActionResult Privacy()
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