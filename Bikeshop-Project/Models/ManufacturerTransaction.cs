using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class ManufacturerTransaction
    {
        [Key]
        public decimal id { get; set; }
        public decimal MANUFACTURERID { get; set; }
        public DateTime TRANSACTIONDATE { get; set; }
        public decimal EMPLOYEEID { get; set; }
        public decimal AMOUNT { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal REFERENCE { get; set; }
    }
}
