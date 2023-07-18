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
        private readonly IWebHostEnvironment _host;

        public ApiController(DemoContext context,IWebHostEnvironment host)
        {
            _context = context;
            _host = host;

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
        public IActionResult CheckAccount(string name)
        {
            var data = _context.Members.FirstOrDefault(x=>x.Name==name);
            if (data != null)
            {
                return Content("1");
            }
            else { return Content("0"); }
        }
        [HttpPost]
        public IActionResult UploadProfilePhoto(IFormFile file)
        {
            string path = Path.Combine(_host.WebRootPath, "uploads", file.FileName);

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                file.CopyTo(fileStream);
            }
            return Content($"上傳成功!檔案位置:{path}");
        }




    }
}
