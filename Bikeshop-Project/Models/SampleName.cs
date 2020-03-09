using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class SampleName
    {
        [Key]
        public Decimal ID { get; set; }
        public string LASTNAME { get; set; }
        public string FIRSTNAME { get; set; }
        public string GENDER { get; set; }
    }
}
