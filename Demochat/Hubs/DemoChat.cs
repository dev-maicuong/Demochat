using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
namespace Demochat.Hubs
{
    
    public class DemoChat : Hub
    {
        public static void Message()
        {
            IHubContext context = GlobalHost.ConnectionManager.GetHubContext<DemoChat>();
            context.Clients.All.displayChat();
        }
    }
}