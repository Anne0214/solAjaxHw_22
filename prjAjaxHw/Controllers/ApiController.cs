using Microsoft.AspNetCore.Mvc;
using prjAjaxHw.Models;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace prjAjaxHw.Controllers
{
    public class ApiController : Controller
    {
        private readonly DemoContext _context;

        public ApiController(DemoContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Cities()
        {
            var datas = _context.Address.Select(x => x.City).Distinct();

            return Json(datas);
        }

        public IActionResult Countries(string city)
        {
            //string keyword = HttpUtility.UrlDecode(city);
            string keyword = WebUtility.UrlDecode(city); 
            var datas = _context.Address.Where(x => x.City == keyword).Select(x => x.SiteId).Distinct();
            
            return Json(datas);
        }

        public IActionResult street(string country)
        {
            string keyword = WebUtility.UrlDecode(country); 
            var datas = _context.Address.Where(x => x.SiteId.Contains(keyword)).Select(x => x.Road);
            return Json(datas);
        }



    }
}
