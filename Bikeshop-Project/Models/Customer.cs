using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bikeshop_Project.Validation;

namespace Bikeshop_Project.Models
{
    public class Customer
    {
        public decimal CUSTOMERID { get; set; }

        [PhoneNumberValidation(ErrorMessage = "Please enter a correct phone number")]
        public string PHONE { get; set; }

        public string FIRSTNAME { get; set; }

        public string LASTNAME { get; set; }

        public string ADDRESS { get; set; }

        public string ZIPCODE { get; set; }

        public decimal CITYID { get; set; }

        public decimal BALANCEDUE { get; set; }
    }
}
