using System;
using System.IO;
using System.Text.Encodings.Web;
using dotnetCoreMVC.Models;

namespace dotnetCoreMVC.ServerStartConfiguration;

public class ServerStart
{
   public static int Configuration(bool toConfigure)
   {
      if(toConfigure == false)
         return 0;

      foreach (string line in File.ReadLines("Users.txt"))
      {
         if(!line.Contains("email::"))
            continue;

         string[] userInfo = line.Split(new string[] {"email::","tag::","user::"}, StringSplitOptions.None);

         Lists.userList.Add(new User{email = userInfo[1].TrimEnd(), tag = userInfo[2].TrimEnd(), name = userInfo[3].TrimEnd()});

      }

      StreamReader reader = new StreamReader("messages.txt");
      
      while (true)
      {
         string? line = reader.ReadLine();

         if(line == null)
            break;

         if(!line.Contains("user::"))
            continue;

         string? user = "";

         if(line != null)
            user = line.Substring(line.IndexOf("user::") + 6);

         line = reader.ReadLine();
         
         string? date = "";
         
         if(line != null)
            date = line.Substring(line.IndexOf("date::") + 6);

         line = reader.ReadLine();

         string? msg = "";

         if(line != null)
            msg = line.Substring(line.IndexOf("msg::") + 5);

         msg = msg.Replace("::","\n");
         msg = msg.Replace("\\:",":");

         line = reader.ReadLine();
         
         string? media = "";

         if(line != null)
            media  = line.Substring(line.IndexOf("msg::") + 5);

         Lists.msgList.Add(new UserMsg{sender = user, date = date, content = msg, media = media});
      }

      return 1;
   }
}
