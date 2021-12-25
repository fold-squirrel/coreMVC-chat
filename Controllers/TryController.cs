using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetCoreMVC.Models;

namespace dotnetCoreMVC.Controllers;

public class TryController : Controller
{

   public IActionResult Display()
   {
      return View();
   }

   public ActionResult chat()
   {
      ChatMessage tryMsg = new ChatMessage
      {
         msg = "this is a message shown using ajax"
      };

      return Json(tryMsg);
   }
}
