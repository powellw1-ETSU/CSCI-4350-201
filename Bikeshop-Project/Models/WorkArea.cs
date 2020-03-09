using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class WorkArea
    {
        [Key]
        public string WORKAREAID { get; set; }

        public string DESCRIPTION { get; set; }
    }
}
