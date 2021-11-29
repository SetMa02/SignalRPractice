using System.Threading.Tasks;

namespace EbaniyServer
{
    public interface IMessageClient
    {
        Task Send(NewMessage message);
    }
}