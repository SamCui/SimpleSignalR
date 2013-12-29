using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace SignalRTest
{
    public class DataHub: Hub
    {
        //public DataHub()
        //{
        //}
        public void Connect(string userName)
        {
            var id = Context.ConnectionId;
            Clients.Caller.onConnected(id);
            SendMessage(userName);
            if(userName =="sam")
                SendPrivateMessage(userName);
        }

        public void SendMessage(string userName)
        {
            Clients.All.messageReceived(userName + " " +"says", "there is a message from the server");
        }

        public void SendPrivateMessage(string userName)
        {
            var id = Context.ConnectionId;
            Clients.Client(id).sendPrivateMessage(id, userName,  "received a private message");
            Clients.Caller.sendPrivateMessage(id, userName, "received a private message 2"); 
        }
    }
}