using System.Threading.Tasks;
using Proto_API_Yugi.Models.Implementation;

namespace Proto_API_Yugi.Clients.Interface
{
    public interface IYgoproDeckClient
    {
         Task<ResponseCard> GetCardByIdAsync(string id);
    }
}