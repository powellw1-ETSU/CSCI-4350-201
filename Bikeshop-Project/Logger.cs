using System;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using Bikeshop_Project.LoggerModels;

namespace Bikeshop_Project
{
    /// <summary>
    /// This class is used for Logging functionality of our program. Calls to this class's static methods
    /// will send data to the Monitoring Team's API.
    /// </summary>
    public static class Logger
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string baseUri = "https://monitoringteamapi.azurewebsites.net/api";
        private static readonly string pageExtension = "pages";
        private static readonly string logsExtension = "logs";
        private static readonly string userExtension = "applicationusers";

        /// <summary>
        /// Used to log PageInfo
        /// </summary>
        /// <param name="page"></param>
        public static async void logPage(PageInfo page)
        {
            string uri = $"{baseUri}/{pageExtension}";
            var json = JsonConvert.SerializeObject(page);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, content);
            Console.WriteLine("Hello");
        }

        /// <summary>
        /// Used to log general information about a User's session
        /// </summary>
        /// <param name="generalLog"></param>
        public static async void logLogs(Logs generalLog)
        {
            string uri = $"{baseUri}/{logsExtension}";
            var json = JsonConvert.SerializeObject(generalLog);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync(uri, content);
        }

        /// <summary>
        /// Used to log information about the user
        /// </summary>
        /// <param name="user"></param>
        public static async void logUsers(User user)
        {
            string uri = $"{baseUri}/{userExtension}";
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync(uri, content);
        }
    }
}
