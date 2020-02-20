using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class RevisionHistory
    {
        [Key]
        public decimal ID { get; set; }
        public string VERSION { get; set; }
        public DateTime CHANGEDATE { get; set; }
        public string NAME { get; set; }
        public string REVISIONCOMMENTS { get; set; }

    }
}
