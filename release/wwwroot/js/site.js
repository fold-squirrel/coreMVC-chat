// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


var email = "";
var userName = "";

function re(){
        window.location.href = '/Login/login'
}

function uploadFile(){
  var input = document.getElementById("files");
  var files = input.files;
  var formData = new FormData();

  for (var i = 0; i != files.length; i++) {
    formData.append("file", files[i]);
  }

    const xhr = new XMLHttpRequest();
    
    xhr.open('POST', 'UploadFile');
    xhr.onload = function() {
        console.log("uploaded");
        console.log(formData.toString())
    };
    xhr.send(formData);
}

function func(){

   const xhttp = new XMLHttpRequest();

   xhttp.onload = function() {
      console.log("done");
   }
   xhttp.open("GET", "/Login/login12?useless=" + Math.floor(Math.random() * 1000) + 1)
   xhttp.send();
}


function func2(){
    email = localStorage.getItem('email');
    document.getElementById("savedEmail").value = email;
}

function num12(){
    const xhr = new XMLHttpRequest();
    
    xhr.open('POST', '/Chat/getnum');
    xhr.setRequestHeader('Content-Type', "application/x-www-form-urlencoded");
    xhr.onload = function() {
        document.getElementById("num").innerHTML = this.responseText.trim();
    };
    xhr.send();
}


function closeMessage() {
    return "Are you sure you want to leave this page";
}

document.addEventListener('visibilitychange', function logData() {
  if (document.visibilityState === 'hidden') {
      const reg = /.*ChatArea/g;
      if (window.location.href.toString().match(reg))
        navigator.sendBeacon("../Login/logout");
  }
});

function sendName(){
    userName = document.getElementById("nameTextBox").value;
    localStorage.setItem('name', userName);
    const xhr = new XMLHttpRequest();
    
    xhr.open('POST', 'setName');
    xhr.setRequestHeader('Content-Type', "application/x-www-form-urlencoded");
    xhr.onload = function() {
        console.log("user added");
        window.location.href = '/Chat/ChatArea'
    };
    xhr.send("name=" + userName);
}

function sendEmail(){
    email = document.getElementById ("emailTextBox").value
    localStorage.setItem('email', email);
    console.log("sendEmail");
    const xhr = new XMLHttpRequest();
    
    xhr.open('POST', 'Email');
    xhr.setRequestHeader('Content-Type', "application/x-www-form-urlencoded");
    xhr.onload = function() {
        if(this.responseText.trim() === "not regestered"){
            window.location.href = '/Login/regester';
        }
        else if(this.responseText.trim() === "logged in"){
            window.location.href = '/Chat/ChatArea'
        }
        else{
            alert("enter a valid email");
        }
    };
    xhr.send("userEmail=" + email);
}
function addMessage(){
    const xhr = new XMLHttpRequest();
    const message = document.getElementById("messageTextBox").value;
    console.log(message);
    xhr.open('POST', 'addMessage');
    xhr.setRequestHeader('Content-Type', "application/x-www-form-urlencoded");
    xhr.onload = function() {
        console.log(message);
    };
    xhr.send("message=" + message);
}

function ajaxChatStart(){
   const xhttp = new XMLHttpRequest();

   xhttp.onload = function() {
        var parsedMsg = JSON.parse(this.responseText);
        if(parsedMsg == null)
           return;
        for(const messages of parsedMsg){
            if(messages.media != null){
                document.getElementById("chatArea").innerHTML +="<h1>" + messages.sender + "</h1><br><img width=\"400px\" src=\"../../" + messages.media + "\">" + "<br><br>";
                continue;
            }
            document.getElementById("chatArea").innerHTML += "<p><h1>" + messages.sender + "</h1>" + "" + messages.content + "</p></br>";
        }
   }
   xhttp.open("Post", "/Chat/onFirstLoad");
   xhttp.send();
}
function ajaxChat(){
   const xhttp = new XMLHttpRequest();

   xhttp.onload = function() {
        var parsedMsg = JSON.parse(this.responseText);
        if(parsedMsg == null)
           return;
        for(const messages of parsedMsg){
            if(messages.media != null){
                document.getElementById("chatArea").innerHTML +="<h1>" + messages.sender + "</h1><br><img width=\"400px\" src=\"../../" + messages.media + "\">" + "<br><br>";
                continue;
            }
            document.getElementById("chatArea").innerHTML += "<p><h1>" + messages.sender + "</h1>" + "" + messages.content + "</p></br>";
        }
   }
   xhttp.open("POST", "/Chat/loadNewMessages");
   xhttp.send();
}
