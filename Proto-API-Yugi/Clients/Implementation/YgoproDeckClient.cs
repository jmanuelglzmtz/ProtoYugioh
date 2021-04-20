using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Proto_API_Yugi.Clients.Interface;
using Proto_API_Yugi.Models.Implementation;

namespace Proto_API_Yugi.Clients.Implementation
{
    public class YgoproDeckClient : IYgoproDeckClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _url;

        public YgoproDeckClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _url = "https://db.ygoprodeck.com/api/v7/cardinfo.php";
        }

        public async Task<ResponseCard> GetCardByIdAsync(string id)
        {
            
            //var response = await _httpClient.GetAsync(GetCompleteUrl($"?id={id}"));
            var formatters = new List<MediaTypeFormatter>() {
                //new MyCustomFormatter(),
                new JsonMediaTypeFormatter(),
                new XmlMediaTypeFormatter(),
                new BsonMediaTypeFormatter()
            };

            var response =  await _httpClient.GetAsync(@"https://1bbc2fa4-18d2-4a2b-a51d-4697d86e7101.mock.pstmn.io/card").ConfigureAwait(false);
            
            if (response.IsSuccessStatusCode)
            {
                var r= await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                //return await response.Content.ReadAsAsync<ResponseCard>(formatters).ConfigureAwait(false);
                return JsonConvert.DeserializeObject<ResponseCard>(r);
            }
            else
            {
                throw new Exception(await response.Content.ReadAsStringAsync().ConfigureAwait(false));
            } 
        }
        private string GetCompleteUrl(string endpoint)
        {
            return $"{_url}{(_url.EndsWith("/", StringComparison.Ordinal) ? string.Empty : "/")}{endpoint}";
        }
    }
}