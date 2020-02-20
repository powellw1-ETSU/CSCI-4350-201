using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class Preference
    {
        [Key]
        public string ITEMNAME { get; set; }
        public double VALUE { get; set; }
        public string DESCRIPTION { get; set; }
        public DateTime DATECHANGED { get; set; }
    }
}
