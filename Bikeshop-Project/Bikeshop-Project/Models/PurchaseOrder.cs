using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class PurchaseOrder
    {
        [Key]
        public decimal PURCHASEID { get; set; }
        public decimal EMPLOYEEID { get; set; }
        public decimal MANUFACTURERID { get; set; }
        public decimal TOTALLIST { get; set; }
        public decimal SHIPPINGCOST { get; set; }
        public decimal DISCOUNT { get; set; }
        public DateTime ORDERDATE { get; set; }
        public DateTime RECEIVEDATE { get; set; }
        public decimal AMOUNTDUE { get; set; }
    }
}
