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
        public int orderID { get; private set; }
        public int totalCost { get; private set; }
        public DateTime purchaseDate { get; private set; }
        public int bicycleID { get; private set; }

        public int customerID { get; private set; }

        public Orders(int orderID, int totalCost, DateTime purchaseDate, int bicycleID, int customerID)
        {
            this.orderID = orderID;
            this.totalCost = totalCost;
            this.purchaseDate = purchaseDate;
            this.bicycleID = bicycleID;
            this.customerID = customerID;
        }
    }
}
