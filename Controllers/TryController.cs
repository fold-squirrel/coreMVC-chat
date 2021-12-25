using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using dotnetCoreMVC.Models;
using System.IO;

namespace dotnetCoreMVC.Controllers;

public class TryController : Controller
{

   public IActionResult Display()
   {
      return View();
   }

   public void loadDataFromLocalFile()
   {
      string[] messages = System.IO.File.ReadAllLines("./wwwroot/txtFile.txt");
   }

   public int convert_to_int(int? nullableInt)
   {
      if(nullableInt == null)
         throw new ArgumentException("Session Id was null");
      
      int normalInt = Convert.ToInt32(nullableInt);
      return normalInt;
   }

   public ActionResult chat()
   {
      //loadDataFromLocalFile();
      string[] messages = System.IO.File.ReadAllLines("./wwwroot/txtFile.txt");

      HttpContext.Session.SetInt32("Id", Id.num++);

      ChatMessage tryMsg = new ChatMessage
      {
         msg = messages[convert_to_int(HttpContext.Session.GetInt32("Id"))] 
      };

      return Json(tryMsg);
   }
}

