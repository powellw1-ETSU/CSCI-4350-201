using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bikeshop_Project.Models
{
    public class Bicycle
    {

        [Key]
        public decimal SERIALNUMBER { get; set; }

        public decimal CUSTOMERID { get; set; }

        public string MODELTYPE { get; set; }

        public decimal PAINTID { get; set; }

        public double FRAMESIZE { get; set; }

        public DateTime ORDERDATE { get; set; }

        public DateTime STARTDATE { get; set; }

        public DateTime SHIPDATE { get; set; }

        public decimal SHIPEMPLOYEE { get; set; }

        public decimal FRAMEASSEMBLER { get; set; }

        public decimal PAINTER { get; set; }

        public string CONSTRUCTION { get; set; }

        public decimal WATERBOTTLEBRAZEONS { get; set; }

        public string CUSTOMNAME { get; set; }

        public string LETTERSTYLEID { get; set; }

        public decimal STOREID { get; set; }

        public decimal EMPLOYEEID { get; set; }

        public double TOPTUBE { get; set; }

        public double CHAINSTAY { get; set; }

        public double HEADTUBEANGLE { get; set; }

        public double SEATTUBEANGLE { get; set; }

        public decimal LISTPRICE { get; set; }

        public decimal SALEPRICE { get; set; }

        public decimal SALESTAX { get; set; }

        public string SALESTATE { get; set; }

        public decimal SHIPPRICE { get; set; }

        public decimal FRAMEPRICE { get; set; }

        public decimal COMPONENTLIST { get; set; }

}
}
