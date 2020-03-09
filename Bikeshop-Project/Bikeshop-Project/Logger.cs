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
        private static readonly string baseUri = "http://MonitoringTeamAPI";
        private static readonly string pageInfoExtension = "pageInfo";
        private static readonly string logsExtension = "logs";
        private static readonly string userExtension = "userExtension";


        public static async void logPageInfo(PageInfo page)
        {
            string uri = $"{baseUri}/{pageInfoExtension}";
            var json = JsonConvert.SerializeObject(page);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync(uri, content);
        }

        public static async void logGeneralInfo(Logs generalLog)
        {
            string uri = $"{baseUri}/{logsExtension}";
            var json = JsonConvert.SerializeObject(generalLog);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync(uri, content);
        }

        public static async void logUserInfo(User user)
        {
            string uri = $"{baseUri}/{userExtension}";
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync(uri, content);
        }
    }
}
