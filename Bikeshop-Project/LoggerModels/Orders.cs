using Newtonsoft.Json;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.LoggerModels
{
    /// <summary>
    /// This is a model that will be used to send logging data to the Monitoring team with regards to
    /// an Order purchased by a Customer
    /// </summary>
    public class Orders
    {
        [Key]
        [JsonProperty("orderId")]
        public int orderID { get; private set; }

        [JsonProperty("totalCost")]
        public decimal totalCost { get; private set; }

        [JsonProperty("purchaseDate")]
        public string purchaseDate { get; private set; }

        [JsonProperty("bicycleId")]
        public int bicycleID { get; private set; }

        [JsonProperty("customerId")]
        public int customerID { get; private set; }

        // Empty default constructor
        public Orders() { }

        public Orders(int id, decimal totalCost, DateTime purchaseDate, int bicycleID, int customerID)
        {
            this.orderID = id;
            this.totalCost = totalCost;
            this.purchaseDate = purchaseDate.ToString();
            this.bicycleID = bicycleID;
            this.customerID = customerID;
        }
    }
}
