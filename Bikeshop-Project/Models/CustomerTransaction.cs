using System;

namespace Bikeshop_Project.Models
{
    public class CustomerTransaction
    {
        public decimal CUSTOMERID { get; set; }

        public DateTime TRANSACTIONDATE { get; set; }

        public decimal EMPLOYEEID { get; set; }

        public decimal AMOUNT { get; set; }

        public string DESCRIPTION { get; set; }

        public decimal REFERENCE { get; set; }

        public decimal id { get; set; }
    }
}
