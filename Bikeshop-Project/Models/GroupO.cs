using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class GroupO
    {

        [Key]
        public decimal COMPONENTGROUPID { get; set; }

        public string GROUPNAME { get; set; }

        public string BIKETYPE { get; set; }

        public decimal YEAR { get; set; }

        public decimal ENDYEAR { get; set; }

        public decimal WEIGHT { get; set; }
    }
}
