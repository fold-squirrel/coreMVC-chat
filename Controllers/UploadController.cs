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
    public class UploadController : Controller
    {
       
       public IActionResult Index()
       {
          return View("~/Views/Home/Index.cshtml");
       }

       [HttpPost]
       [RequestFormLimits(MultipartBodyLengthLimit = 104898560)]
       public ActionResult UploadFile([FromForm] List<IFormFile> file)
       {
          foreach (var formFile in file)
          {
             if (formFile.Length > 0)
             {
                using (var stream = new FileStream("Upload/" + file[0].FileName, FileMode.Create))
                {
                   formFile.CopyTo(stream);
                }
             }
          }
          ViewBag.Message += string.Format("{0} file uploaded sucsessfully !!!.", file[0].FileName);
          return View("~/Views/Home/Index.cshtml");
       }

       public IActionResult Privacy()
       {
           return View();
       }
    }
}
