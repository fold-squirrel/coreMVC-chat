using System.Diagnostics;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using dotnetCoreMVC.Models;

namespace dotnetCoreMVC.Controllers;
public class LoginController : Controller
{
    public IActionResult login()
    {
        return View();
    }
    public IActionResult regester()
    {
        return View();
    }
    public string Email(string userEmail)
    {
        Regex regex = new Regex(@"^[\w!#$%&'*+\-/=?\^_`{|}~]+(\.[\w!#$%&'*+\-/=?\^_`{|}~]+)*"
                                    + "@"
                                    + @"((([\-\w]+\.)+[a-zA-Z]{2,4})|(([0-9]{1,3}\.){3}[0-9]{1,3}))$");
        Match match = regex.Match(userEmail);
        if (match.Success != true)
        {
            Console.WriteLine("incorrect email : "+ userEmail );
            return "invalid email";
        }
        HttpContext.Session.SetString("email", userEmail);
        foreach(var user in Lists.userList)
        {
            if(user.email == userEmail)
            {
                HttpContext.Session.SetString("name", user.name);
                return "logged in";
            }
        }

        return "not regestered";
        //return View("~/Views/Try/Nohere.cshtml");
    }

    public void logout()
    {
        Id.num--;
        Console.WriteLine("user Logged out");
    }


    public void login12(int useless)
    {
        Id.num++;
        Console.WriteLine("user Logged in");
    }

    public int getnum()
    {
        return Id.num;
    }

    public void setName(string name)
    {
        HttpContext.Session.SetString("name", name);
        addUser();
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
