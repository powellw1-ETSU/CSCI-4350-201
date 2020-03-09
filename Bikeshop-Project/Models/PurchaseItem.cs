using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class PurchaseItem
    {
        [Key]
        public decimal id { get; set; }
        public decimal PURCHASEID { get; set; }
        public decimal COMPONENTID { get; set; }
        public decimal PRICEPAID { get; set; }
        public decimal QUANTITY { get; set; }
        public decimal QUANTITYRECEIVED { get; set; }
    }
}
