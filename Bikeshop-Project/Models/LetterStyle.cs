using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Models
{
    public class LetterStyle
    {
        [Key]
        public string LETTERSTYLE { get; set; }
        public string DESCRIPTION { get; set; }
    }
}
