using System;
using System.Threading.Tasks;

namespace Proto_API_Yugi.Clients.Interface
{
    public interface IServiceClient
    {
         Task<Byte[]> GetImageCardByUrlAsync(string url);
    }
}