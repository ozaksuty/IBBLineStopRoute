using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace IBBSample.Mobile.Provider
{
    public class ServiceManager
    {
        private static HttpClient _client;
        public static HttpClient Client
        {
            get
            {
                if (_client == null)
                    _client = new HttpClient();
                return _client;
            }
        }

        public async Task<T> Get<T>(string url)
        {
            return JsonConvert.DeserializeObject<T>(await Client.GetStringAsync(url));
        }
    }
}