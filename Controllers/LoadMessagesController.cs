using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetCoreMVC.Models;
using System.IO;
using System.Xml.Serialization;

namespace dotnetCoreMVC.Controllers;

public class LoadMessagesController : Controller
{

    public IActionResult Display()
    {
        return View("~/Views/Home/Index.cshtml");
    }

   public JsonResult onFirstLoad()
    {
        Console.WriteLine("created new session");
        HttpContext.Session.SetInt32("counter", 0);
        var returnedjson = loadNewMessages();
        return returnedjson;
        //reset session counter for loaded images
    } 

    public JsonResult loadNewMessages()
    {
        int? counter = 0;

        counter = HttpContext.Session.GetInt32("counter");

        int nonnullcounter = counter == null ? default(int) : counter.Value;

        if (Lists.msgList.Count == nonnullcounter)
        {
            Console.WriteLine("no new message");
            return Json(null);
        }
        Console.WriteLine("new messages loaded");
        int size = Lists.msgList.Count - nonnullcounter;
            Console.WriteLine(size);
        UserMsg[] arr = new UserMsg[size];
        int j = 0;
        for (int i = nonnullcounter; i < Lists.msgList.Count; i++)
        {
            Console.WriteLine(i);
            Console.WriteLine(j);
            arr[j] = Lists.msgList[i];
            j++;
        }
        HttpContext.Session.SetInt32("counter", Lists.msgList.Count);
        //return json list with new messages
        return Json(arr);
    }

    public void readxml()
    {
        var mxml = new XmlSerializer(typeof(List<UserMsg>));
        
        using (var reader = new StreamReader("messages.txt"))
        {
            var msg = (List<UserMsg>) mxml.Deserialize(reader);
            Lists.msgList = msg;
        };
    }

    public void addMessage(string messages)
    {
        //add message to list
    }        
}


