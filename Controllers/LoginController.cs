using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using dotnetCoreMVC.Models;

namespace dotnetCoreMVC.Controllers;
public class LoginController : Controller
{
    public IActionResult Email(string userEmail)
    {

        return View();
    }

    public ActionResult Name(string Name = String.Empty)
    {

        return View();
    }

    public void addUser()
    {

    }
}

