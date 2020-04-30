using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using Bikeshop_Project.LoggerModels;
using Newtonsoft.Json;
using Xunit;

namespace Bikeshop_Project.Tests.Routes
{
    public class PostRequestTests
    {
        private readonly HttpClient _client;
        private readonly string baseUriDB = "ec2-3-136-108-167.us-east-2.compute.amazonaws.com";
        private readonly string baseUriMonitoring = "monitoringteamapi.azurewebsites.net/api";
        private readonly string pageExtension = "pages";
        private readonly string logsExtension = "logs";
        private readonly string userExtension = "applicationusers";
        private readonly string orderExtension = "orders";


        /// <summary>
        /// Constructor instantiates a new instance of the HttpClient used for testing
        /// </summary>
        public PostRequestTests()
        {
            _client = new HttpClient();
        }

        /// <summary>
        /// This tests the monitoring team API accepts proper POST request for "Logs" objects.
        /// These objects contain metrics for a general user session
        /// </summary>
        [Fact]
        public async void PostRequest_MonitoringTeam_Logs_Correct()
        {
            // Arrange
            Logs testLog = new Logs(DateTime.Now.ToString(),
                                    "this is from testing",
                                    DateTime.Now,
                                    DateTime.Now,
                                    0,
                                    "Sample page title");

            string uri = $"http://{baseUriMonitoring}/{logsExtension}";
            var json = JsonConvert.SerializeObject(testLog);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response;

            // Act
            response = await _client.PostAsync(uri, content);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);
        }

        /// <summary>
        /// This test ensures the monitoring team API is accepting a properly format POST request for a Page metric
        /// </summary>
        [Fact]
        public async void PostRequest_MonitoringTeam_Pages_Correct()
        {
            PageInfo test = new PageInfo(DateTime.Now.ToString(), "this is a test", "Sample username for test");

            string uri = $"http://{baseUriMonitoring}/{pageExtension}";
            var json = JsonConvert.SerializeObject(test);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response;

            // Act
            response = await _client.PostAsync(uri, content);

            // Assert
            Assert.Equal(HttpStatusCode.Created, response.StatusCode);

        }
    }
}
