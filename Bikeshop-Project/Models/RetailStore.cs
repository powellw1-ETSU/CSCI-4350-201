using System;
using System.ComponentModel.DataAnnotations;
using Bikeshop_Project.Validation;

namespace Bikeshop_Project.Models
{
    public class RetailStore
    {
        [Key]
        public decimal STOREID { get; set; }
        public string STORENAME { get; set; }

        [PhoneNumberValidation(ErrorMessage = "Please enter a correct phone number")]
        public string PHONE { get; set; }
        public string CONTACTFIRSTNAME { get; set; }
        public string CONTACTLASTNAME { get; set; }
        public string ADDRESS { get; set; }

        [ZipCodeValidation(ErrorMessage = "Please enter a correct zipcode")]
        public string ZIPCODE { get; set; }
        public decimal CITYID { get; set; }
    }
}
