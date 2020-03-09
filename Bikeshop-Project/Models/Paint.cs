using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class Paint
    {
        [Key]
        public decimal PAINTID { get; set; }
        public string COLORNAME { get; set; }
        public string COLORSTYLE { get; set; }
        public string COLORLIST { get; set; }
        public DateTime DATEINTRODUCED { get; set; }
        public DateTime DATEDISCONTINUED { get; set; }
    }
}
