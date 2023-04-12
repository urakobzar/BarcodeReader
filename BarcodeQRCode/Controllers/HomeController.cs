using BarcodeQRCode.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using ZXing;
using ZXing.QrCode;

namespace BarcodeQRCode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HomeController(ILogger<HomeController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
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
        

        public ActionResult ReadBarCode()
        {
            string webRoothPath = _webHostEnvironment.WebRootPath;
            var path = webRoothPath + "\\img\\Code.png";
            Bitmap image = (Bitmap)Image.FromFile(path);
            BarcodeReader reader = new BarcodeReader();
            var result = reader.Decode(image);
            if (result != null)
            {
                ViewBag.Text = result.Text;
            }
            return View("Index");
        }

    }
}
