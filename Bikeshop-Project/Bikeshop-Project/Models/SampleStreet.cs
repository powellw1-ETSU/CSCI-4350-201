using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class SampleStreet
    {
        [Key]
        public Decimal ID { get; set; }
        public string BASEADDRESS { get; set; }
    }
}
