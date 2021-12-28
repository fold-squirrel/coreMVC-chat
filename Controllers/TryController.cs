using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetCoreMVC.Models;
using System.IO;

namespace dotnetCoreMVC.Controllers;

public class TryController : Controller
{

   public IActionResult Display()
   {
      return View("~/Views/Try/Nohere.cshtml");
   }

   public int convert_to_int(int? nullableInt)
   {
      if (nullableInt == null)
         throw new ArgumentException("Session Id was null");
      
      int normalInt = Convert.ToInt32(nullableInt);
      return normalInt;
   }

   public void incrementSession()
   {
      if (HttpContext.Session.GetInt32("Id") == null)
         HttpContext.Session.SetInt32("Id", 0);
      else
         HttpContext.Session.SetInt32("Id", convert_to_int(HttpContext.Session.GetInt32("Id")) + 1);
   }

   public ActionResult chat()
   {
      //loadDataFromLocalFile();
      string[] messages = System.IO.File.ReadAllLines("./wwwroot/txtFile.txt");

      incrementSession();

      ChatMessage tryMsg = new ChatMessage
      {
         msg = messages[convert_to_int(HttpContext.Session.GetInt32("Id"))] 
      };

      Console.WriteLine(Id.num);
      return Json(tryMsg);
   }
}

