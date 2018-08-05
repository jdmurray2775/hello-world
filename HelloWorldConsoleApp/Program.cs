using HelloWorldAPI.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace HelloWorldConsoleApp
{
    class Program
    {
        static HttpClient client = new HttpClient();

        static async Task<HelloWorldModel> GetModelAsync(string path)
        {
            client.BaseAddress = new Uri("http://localhost:49739/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));

            HelloWorldModel model = null;
            HttpResponseMessage response = await client.GetAsync(path);
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                model = JsonConvert.DeserializeObject<HelloWorldModel>(json);
            }
            return model;
        }

        static void Main(string[] args)
        {
            GetModelTextAsync().GetAwaiter().GetResult();
            Console.ReadLine();
        }

        static async Task GetModelTextAsync()
        {
            var response = await GetModelAsync("api/helloworld/1");
            Console.Write(response.Text);
        }

    }
}
