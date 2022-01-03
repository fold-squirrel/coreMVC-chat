using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetCoreMVC.Models;
using System.IO;

namespace dotnetCoreMVC.Controllers;

public class LoadMessagesController : Controller
{

    public IActionResult Display()
    {
        return View("~/Views/Home/Index.cshtml");
    }

    public ActionResult onFirstLoad()
    {
        //reset session counter for loaded images
    } 

    public JsonResult newMessages()
    {
        //return json list with new messages
    }

    public void addMessage(string messages)
    {
        //add message to list
    }
}


