using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class TempDateMade
    {
        [Key]
        public DateTime DATEVALUE { get; set; }
        public Double MADECOUNT { get; set; }
    }
}
