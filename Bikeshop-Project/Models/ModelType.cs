using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class ModelType
    {
        [Key]
        public string MODELTYPE { get; set; }
        public string DESCRIPTION { get; set; }
        public decimal COMPONENTID { get; set; }
    }
}
