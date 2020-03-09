using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class StateTaxRate
    {
        [Key]
        public String STATE { get; set; }
        public Double TAXRATE { get; set; }
    }
}
