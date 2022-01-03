using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Collections.Generic;
using dotnetCoreMVC.Models;

using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Http.Features;
var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<KestrelServerOptions>(options =>
{
     options.Limits.MaxRequestBodySize = int.MaxValue; // if don't set default value is: 30 MB
});

builder.Services.Configure<FormOptions>(x =>
{
     x.ValueLengthLimit = int.MaxValue;
     x.MultipartBodyLengthLimit = int.MaxValue; // if don't set default value is: 128 MB
     x.MultipartHeadersLengthLimit = int.MaxValue;
});

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache();

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromSeconds(600);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

//app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseSession();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

var axml = new XmlSerializer(typeof(List<User>));

using (var reader = new StreamReader("Users.txt"))
{
    var users = (List<User>) axml.Deserialize(reader);
    Lists.userList = users;
};

var mxml = new XmlSerializer(typeof(List<UserMsg>));

using (var reader = new StreamReader("messages.txt"))
{
    var msg = (List<UserMsg>) mxml.Deserialize(reader);
    Lists.msgList = msg;
};

app.Run();

string s; 

using (var writer = new StringWriter())
{
    axml.Serialize(writer, Lists.userList);
    s = writer.ToString();
};
XmlDocument xmlDoc = new XmlDocument();
var sw = new StreamWriter("Users.txt");
xmlDoc.LoadXml(s);
xmlDoc.Save(sw);
sw.Close();

using (var writer = new StringWriter())
{
    mxml.Serialize(writer, Lists.msgList);
    s = writer.ToString();
};
XmlDocument xmlDo = new XmlDocument();
var w = new StreamWriter("messages.txt");
xmlDoc.LoadXml(s);
xmlDoc.Save(w);
w.Close();
