using System.Net;
using System.Net.Http;
using Xunit;

namespace Bikeshop_Project.Tests.Routes
{
    /// <summary>
    /// This class will test all of the Database team's routes using GET Requests.
    /// It is only verifying that the request returns a (200 OK) status request. If not, there is a problem with our server and/or API.
    /// </summary>
    public class GetRequestTests
    {
        private readonly HttpClient _client;
        private readonly string baseUriDB = "bikeshopproject-prod.us-east-2.elasticbeanstalk.com";
        private readonly string baseUriMonitoring = "monitoringteamapi.azurewebsites.net/api";

        /// <summary>
        /// Constructor instantiates a new instance of the HttpClient used for testing
        /// </summary>
        public GetRequestTests()
        {
            _client = new HttpClient();
        }

        [Theory]
        [InlineData("Bicycles")]
        [InlineData("BicycleTubeUsages")]
        [InlineData("BikeParts")]
        [InlineData("BikeTubes")]
        [InlineData("Cities")]
        [InlineData("CommonSizes")]
        [InlineData("ComponentNames")]
        [InlineData("Components")]
        [InlineData("Customers")]
        [InlineData("CustomerTransactions")]
        [InlineData("Employees")]
        [InlineData("GroupComponents")]
        [InlineData("GroupOes")]
        [InlineData("Home")]
        [InlineData("LetterStyles")]
        [InlineData("Manufacturers")]
        [InlineData("ManufacturerTransactions")]
        [InlineData("ModelSizes")]
        [InlineData("ModelTypes")]
        [InlineData("Orders")]
        [InlineData("Paints")]
        [InlineData("Preferences")]
        [InlineData("PurchaseItems")]
        [InlineData("PurchaseOrders")]
        [InlineData("RetailStores")]
        [InlineData("RevisionHistories")]
        [InlineData("SampleNames")]
        [InlineData("SampleStreets")]
        [InlineData("StateTaxRates")]
        [InlineData("TempDateMades")]
        [InlineData("TubeMaterials")]
        [InlineData("WorkAreas")]
        public async void GetRequests_DatabaseRoutes(string endpoint)
        {
            // Arrange
            HttpResponseMessage response;                   // will hold http status code response from server
            string uri = $"http://{baseUriDB}/{endpoint}";    // uri to send request to

            // Act
            response = await _client.GetAsync(uri);         // send the request

            // Assert (if request was successful <returns 200> test succeeds)
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Theory]
        [InlineData("pages")]
        [InlineData("logs")]
        [InlineData("applicationusers")]
        public async void GetRequests_MonitoringRoutes(string endpoint)
        {
            // Arrange
            HttpResponseMessage response;                   // will hold http status code response from server
            string uri = $"http://{baseUriMonitoring}/{endpoint}";    // uri to send request to

            // Act
            response = await _client.GetAsync(uri);         // send the request

            // Assert (if request was successful <returns 200> test succeeds)
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
