using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class TubeMaterial
    {
        [Key]
        public Decimal TUBEID { get; set; }
        public String MATERIAL { get; set; }
        public String DESCRIPTION { get; set; }
        public Double DIAMETER { get; set; }
        public Double THICKNESS { get; set; }
        public String ROUNDNESS { get; set; }
        public Double WEIGHT { get; set; }
        public Double STIFFNESS { get; set; }
        public Double LISTPRICE { get; set; }
        public String CONSTRUCTION { get; set; }
    }
}
