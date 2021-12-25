// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function ajaxChat(){
   const xhttp = new XMLHttpRequest();

   xhttp.onload = function() {
      var parsedMsg = JSON.parse(this.responseText);
      document.getElementById("chatArea").innerText += parsedMsg.msg + "\n";
   }
   xhttp.open("Get", "Try/chat");
   xhttp.send();
}
