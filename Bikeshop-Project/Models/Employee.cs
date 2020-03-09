using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bikeshop_Project.Models
{
    public class Employee
    {
         public decimal EMPLOYEEID { get; set; }

        public string TAXPAYERID { get; set; }

        public string LASTNAME { get; set; }

        public string FIRSTNAME { get; set; }

        public string HOMEPHONE { get; set; }

        public string ADDRESS { get; set; }

        public string ZIPCODE { get; set; }

        public decimal CITYID { get; set; }

        public DateTime DATEHIRED { get; set; }

        public DateTime DATERELEASED { get; set; }

        public decimal CURRENTMANAGER { get; set; }

        public decimal SALARYGRADE { get; set; }

        public decimal SALARY { get; set; }

        public string TITLE { get; set; }

        public string WORKAREA { get; set; }

    }
}
