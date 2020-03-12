using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Bikeshop_Project.LoggerModels;

namespace Bikeshop_Project
{
    public static class Logger
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string baseUri = "https://monitoringteamapi.azurewebsites.net/api";
        private static readonly string pageExtension = "pages";
        private static readonly string logsExtension = "logs";
        private static readonly string userExtension = "applicationusers";


        public static async void logPage(PageInfo page)
        {
            string uri = $"{baseUri}/{pageExtension}";
            var json = JsonConvert.SerializeObject(page);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, content);
            Console.WriteLine("Hello");
        }

        public static async void logLogs(Logs generalLog)
        {
            string uri = $"{baseUri}/{logsExtension}";
            var json = JsonConvert.SerializeObject(generalLog);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync(uri, content);
        }

        public static async void logUsers(User user)
        {
            string uri = $"{baseUri}/{userExtension}";
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync(uri, content);
        }
    }
}
