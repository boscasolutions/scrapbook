namespace ChatApp.Hubs
{
    using Microsoft.AspNet.SignalR;

    public class DemoHub : Hub
    {
        public void Send(string message)
        {
            Clients.All.newMessage(
                Context.User.Identity.Name + " Says: " + message
                );
        }
    }
}