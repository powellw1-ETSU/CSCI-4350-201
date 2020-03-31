using System;
using System.ComponentModel.DataAnnotations;
using Bikeshop_Project.Validation;

namespace Bikeshop_Project.Models
{
    public class Manufacturer
    {
        [Key]
        public decimal MANUFACTURERID { get; set; }
        public string MANUFACTURERNAME { get; set; }
        public string CONTACTNAME { get; set; }

        [PhoneNumberValidation(ErrorMessage = "Please enter a correct phone number")]
        public string PHONE { get; set; }
        public string ADDRESS { get; set; }

        [ZipCodeValidation(ErrorMessage = "Please enter a correct zipcode")]
        public string ZIPCODE { get; set; }
        public decimal CITYID { get; set; }
        public decimal BALANCEDUE { get; set; }
    }
}
