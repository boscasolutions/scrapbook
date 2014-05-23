namespace ChatApp.Hubs
{
    using System.Threading.Tasks;
    using Counters;
    using Microsoft.AspNet.SignalR;

    public class DemoHub : Hub
    {
        public DemoHub()
        {
            StartCountersCollection();
        }

        private void StartCountersCollection()
        {
            var task = Task.Factory.StartNew(async () =>
            {
                var prefProvider = new PrefCountersProvider();
                while (true)
                {
                    var results = prefProvider.GetResults();

                    Clients.All.newCounters(results);

                    await Task.Delay(2000);
                }
            } , TaskCreationOptions.LongRunning);
        }

        public void Send(string message)
        {
            Clients.All.newMessage(
                Context.User.Identity.Name + " Says: " + message
                );
        }
    }
}