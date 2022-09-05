"use strict";
/*通过路由地址建立与signlr连接*/

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();
 

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;
/* 监听服务器中的Hub*/
connection.on("Send", function (message) {
    console.log("监听到消息");
    console.log(message);
    var historyMess = document.getElementById("myChatRoom");
    var myText = document.createTextNode(message);
    var myEle = document.createElement("li");
    myEle.appendChild(myText);
    historyMess.appendChild(myEle);
    document.getElementById("messageInput").value = "";
});
connection.on("Send", function (message) {
  
    console.log(message);
});
/*添加到组*/
document.getElementById("join-group").addEventListener("click", async (event) => {
    var groupName = document.getElementById("group-name").value;
    try {
        document.getElementById("myChatRoom").style.display = "block"
        /*调用hub中的方法*/
        await connection.invoke("AddToGroup", groupName);
       
    }
    catch (e) {
        console.error(e.toString());
    }
    event.preventDefault();
});
/*退出聊天室*/
document.getElementById("outRoomButton").addEventListener("click", () => {
    document.getElementById("myChatRoom").style.display = "none";
    alert("退出成功");
})

/*检测与hub的连接是否成功打开*/
connection.start().then(function () {
    console.log("连接打开");
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});


document.getElementById("sendButton").addEventListener("click", function (event) {
    var groupName = document.getElementById("group-name").value;
    console.log("向hub发送消息");
    var user = document.getElementById("userInput").value;
    var message = document.getElementById("messageInput").value;

    /*向singlr发送消息*/

    connection.invoke("SendMessageToGroup", groupName,message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});