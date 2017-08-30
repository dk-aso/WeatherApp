using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    class DataService
    {
        public static async Task<dynamic> getDataFromService(string pQueryString)
        {
            HttpClient client = new HttpClient();
            var response = await client.GetAsync(pQueryString);
            dynamic data = null;
            if (response != null)
            {
                string json = response.Content.ReadAsStringAsync().Result;
                data = JsonConvert.DeserializeObject(json);
            }
            return data;
        }
    }
}
