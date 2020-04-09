using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class ModelSize
    {
        [Key]
        public decimal id { get; set; }
        public string MODELTYPE { get; set; }
        public double MSIZE { get; set; }
        public double TOPTUBE { get; set; }
        public double CHAINSTAY { get; set; }
        public double TOTALLENGTH { get; set; }
        public double GROUNDCLEARANCE { get; set; }
        public double HEADTUBEANGLE { get; set; }
        public double SEATTUBEANGLE { get; set; }
    }
}
