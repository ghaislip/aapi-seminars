using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Aapi.Seminars.Extensions
{
    public static class HttpContentExtensions
    {
        public static async Task<T> ReadAsAsync<T>(this HttpContent self) where T : class
        {
            var data = await self.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
