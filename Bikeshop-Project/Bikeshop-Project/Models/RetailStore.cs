using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class RetailStore
    {
        [Key]
        public decimal STOREID { get; set; }
        public string STORENAME { get; set; }
        public string PHONE { get; set; }
        public string CONTACTFIRSTNAME { get; set; }
        public string CONTACTLASTNAME { get; set; }
        public string ADDRESS { get; set; }
        public string ZIPCODE { get; set; }
        public decimal CITYID { get; set; }
    }
}
