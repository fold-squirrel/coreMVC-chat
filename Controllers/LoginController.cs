using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetCoreMVC.Models;

namespace dotnetCoreMVC.Controllers;
public class LoginController : Controller
{
    public IActionResult Email(string userEmail)
    {
        Console.WriteLine(userEmail);
        HttpContext.Session.SetString("email", userEmail);
        foreach(var user in Lists.userList)
        {
            if(user.email == userEmail)
            {
                HttpContext.Session.SetString("name", user.name);
                return View("~/Views/Home/Index.cshtml");
            }
        }

        return View("~/Views/Home/Index.cshtml");
    }

    public ActionResult setName(string name )
    {
        HttpContext.Session.SetString("name", name);
        addUser();
        return View();
    }

    public void addUser()
    {
        Lists.userList.Add(new User
        {
            name = HttpContext.Session.GetString("name"),
            email = HttpContext.Session.GetString("email"),
            tag= "0000"
        });

    }
}
