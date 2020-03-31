using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Bikeshop_Project.Validation;

namespace Bikeshop_Project.Models
{
    public class Employee
    {
        public decimal EMPLOYEEID { get; set; }

        public string TAXPAYERID { get; set; }

        public string LASTNAME { get; set; }

        public string FIRSTNAME { get; set; }

        [PhoneNumberValidation(ErrorMessage = "Please enter a correct phone number")]
        public string HOMEPHONE { get; set; }

        public string ADDRESS { get; set; }

        [ZipCodeValidation(ErrorMessage = "Please enter a correct zipcode")]
        public string ZIPCODE { get; set; }

        public decimal CITYID { get; set; }

        public DateTime DATEHIRED { get; set; }

        public DateTime DATERELEASED { get; set; }

        public decimal CURRENTMANAGER { get; set; }

        public decimal SALARYGRADE { get; set; }

        [Range(0, 100000000000000, ErrorMessage = "Salary may not be negative")]
        public decimal SALARY { get; set; }

        public string TITLE { get; set; }

        public string WORKAREA { get; set; }

    }
}
