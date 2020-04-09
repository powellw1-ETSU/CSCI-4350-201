using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class ComponentName
    {
        [Key]
        public string COMPONENTNAME { get; set; }

        public decimal ASSEMBLYORDER { get; set; }

        public string DESCRIPTION { get; set; }
    }
}
