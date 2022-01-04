// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.



function ajax(){
   const xhttp = new XMLHttpRequest();

   xhttp.onload = function() {
      var parsedMsg = JSON.parse(this.responseText);
      document.getElementById("chatArea").innerText += parsedMsg[0].content + "\n\n\n\n";
      document.getElementById("chatArea").innerText += parsedMsg[1].content + "\n";
   }
   xhttp.open("Get", "LoadMessages/loadNewMessages");
   xhttp.send();
}
function xml(){
   const xhttp = new XMLHttpRequest();

   xhttp.onload = function() {
       console.log("loaded xml");
   }
   xhttp.open("Get", "LoadMessages/readxml");
   xhttp.send();
}
function ajaxChat(){
   const xhttp = new XMLHttpRequest();

   xhttp.onload = function() {
      var parsedMsg = JSON.parse(this.responseText);
      document.getElementById("chatArea").innerText += parsedMsg[0].content + "\n\n\n\n";
      document.getElementById("chatArea").innerText += parsedMsg[1].content + "\n";
   }
   xhttp.open("Get", "LoadMessages/onFirstLoad");
   xhttp.send();
}
