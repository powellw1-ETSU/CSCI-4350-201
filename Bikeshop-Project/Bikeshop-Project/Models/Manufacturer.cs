using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class Manufacturer
    {
        [Key]
        public decimal MANUFACTURERID { get; set; }
        public string MANUFACTURERNAME { get; set; }
        public string CONTACTNAME { get; set; }
        public string PHONE { get; set; }
        public string ADDRESS { get; set; }
        public string ZIPCODE { get; set; }
        public decimal CITYID { get; set; }
        public decimal BALANCEDUE { get; set; }
    }
}
