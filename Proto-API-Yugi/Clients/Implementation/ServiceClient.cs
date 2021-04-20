using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proto_API_Yugi.Clients.Interface;

namespace Proto_API_Yugi.Clients.Implementation
{
    public class ServiceClient : IServiceClient
    {
        #region :: Properties ::
        /// <summary>
        /// HttpClient
        /// </summary>
        protected readonly HttpClient _httpClient;

        #endregion

        #region :: Constructor ::

        public ServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        #endregion

        #region :: Methods ::

        public async Task<Byte[]> GetImageCardByUrlAsync(string url)
        {
            var response =  await _httpClient.GetAsync(url).ConfigureAwait(false);
            if(response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsByteArrayAsync().ConfigureAwait(false);
            }            
            return null;
        }
        #endregion
    }
}