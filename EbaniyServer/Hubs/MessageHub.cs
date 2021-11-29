using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace EbaniyServer.Hubs
{
    public class MessageHub : Hub<IMessageClient>
    {
        public Task SendToOthers(Message message)
        {
            var messageForClient = NewMessage.Create(Context.Items["Name"] as string, message);
            return Clients.Others.Send(messageForClient);
        }

        public Task SetMyName(string name)
        {
            if(string.IsNullOrWhiteSpace(name))
                return Task.CompletedTask;
            if (Context.Items.ContainsKey("Name"))
                Context.Items["Name"] = name;
            else
                Context.Items.Add("Name", name);
            return Task.CompletedTask;
        }

        public Task<string> GetMyName()
        {
            if (Context.Items.ContainsKey("Name"))
                return Task.FromResult(Context.Items["Name"] as string);

            return Task.FromResult("Anonymous");
        }
    }
}