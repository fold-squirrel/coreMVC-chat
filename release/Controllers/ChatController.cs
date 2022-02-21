using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetCoreMVC.Models;
using System.IO;
using System.Xml.Serialization;

namespace dotnetCoreMVC.Controllers;

public class ChatController : Controller
{

    public ActionResult ChatArea()
    {
        return View();
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

    public void addMessage(string message)
    {
        //add message to list
        Lists.msgList.Add(new UserMsg { 
                    sender = HttpContext.Session.GetString("name"),
                    date = DateTime.Now.ToString("hh:mm"),
                    content = message,
                    media = null
                });
    }        

       [HttpPost]
       [RequestFormLimits(MultipartBodyLengthLimit = 104898560)]
       public async Task<IActionResult> UploadFile([FromForm] List<IFormFile> file)
       {
           int i=0;
          foreach (var formFile in file)
          {
             if (formFile.Length > 0)
             {
                using (var stream = new FileStream("wwwroot/Upload/" + formFile.FileName, FileMode.Create))
                {
                   await formFile.CopyToAsync(stream);
                }
                addMedia("/Upload/" + file[i++].FileName);
             }
          }

          return View("~/Views/Chat/ChatArea.cshtml");
       }

       public void addMedia(string path)
       {
           Lists.msgList.Add(new UserMsg {
                        sender = HttpContext.Session.GetString("name"),
                        date = DateTime.Now.ToString("HH:mm"),
                        media = path
                   });
           Console.WriteLine("saved and path is " + path);
       }

       public IActionResult Privacy()
       {
           return View();
       }
    
       public int getnum()
       {
           return Id.num;
       }
}


