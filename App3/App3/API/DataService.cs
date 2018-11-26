using Newtonsoft.Json;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http;

namespace App3.API
{
    public class DataService
    {
        public static async Task<dynamic> GetDataFromService(string queryString)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", "Bearer v4cfl377tx3qn7h43gibc3ctb5b0d8oc");
            var response = await client.GetAsync(queryString);

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
