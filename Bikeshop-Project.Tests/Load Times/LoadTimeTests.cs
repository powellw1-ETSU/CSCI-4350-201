using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using Xunit;

namespace Bikeshop_Project.Tests.Load_Times
{
    public class LoadTimeTests
    {
        private readonly HttpClient _client;
        private readonly string baseUriDB = "ec2-3-136-108-167.us-east-2.compute.amazonaws.com";
        private readonly int requiredMilliseconds = 2000;

        /// <summary>
        /// Constructor instantiates a new instance of the HttpClient used for testing
        /// </summary>
        public LoadTimeTests()
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
        public async void LoadTimeAPITests(string endpoint)
        {
            // Arrange
            HttpResponseMessage response;                   // will hold http status code response from server
            string uri = $"http://{baseUriDB}/{endpoint}";  // uri to send request to
            Stopwatch sw = new Stopwatch();
            bool testPassed = false;

            // Act
            sw.Start();                                 // start stopwatch
            response = await _client.GetAsync(uri);     // send the request
            sw.Stop();                                  // stop stopwatch

            // Assert (if data was returned fast enough, test is successful.)
            if (sw.ElapsedMilliseconds < requiredMilliseconds) { testPassed = true; }

            Assert.Equal(true, testPassed);
        }
    }
}
