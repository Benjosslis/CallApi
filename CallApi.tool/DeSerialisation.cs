using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CallApi.tool
{
    public class DeSerialisation
    {
        public T GetCall<T>(string url)
        {
            string jsonFlux = GetDataFromApi(url);
            var result = JsonSerializer.Deserialize<T>(jsonFlux);
            return result;
        }

        public string GetDataFromApi(string url)
        {
            string result = null;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(url);
            result = client.GetStringAsync(url).Result;
            return result; 
        }

       
    }
}
