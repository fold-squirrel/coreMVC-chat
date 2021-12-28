using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnetCoreMVC.Models;
using Microsoft.AspNetCore.Http;
using System.IO;
namespace dotnetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
       
       public IActionResult Index()
       {
          return View();
       }

       [HttpPost]
       [RequestFormLimits(MultipartBodyLengthLimit = 104898560)]
       public ActionResult FileUpload(/*[FromForm] IFormFile postedFile*/)
       {
          var files = Request.Form.Files;
          string path = "Upload";
          string fileName = "hellllo1.data";

          foreach (var formFile in files)
          {
             if (formFile.Length > 0)
             {
                using (var stream = new FileStream("Upload/video.mp4", FileMode.Create))
                {
                   formFile.CopyTo(stream);
                }
             }
          }
         // using (var stream = new FileStream(Path.Combine(path,fileName), FileMode.Create))
         // {
         //    ViewBag.Message += string.Format("<b>{0}</b> files Up and Running.<br>", fileName);
         //    postedFile.CopyTo(stream);
         // }
          return View();
       }

       public IActionResult Privacy()
       {
           return View();
       }
    }
}
//using System.Diagnostics;
//using Microsoft.AspNetCore.Mvc;
//using dotnetCoreMVC.Models;
//
//namespace dotnetCoreMVC.Controllers;
//
//public class HomeController : Controller
//{
//    private readonly ILogger<HomeController> _logger;
//
//    public HomeController(ILogger<HomeController> logger)
//    {
//        _logger = logger;
//    }
//
//    public IActionResult Index()
//    {
//        return View();
//    }
//
//    public IActionResult Privacy()
//    {
//        return View();
//    }
//
//    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
//    public IActionResult Error()
//    {
//        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
//    }
//}
