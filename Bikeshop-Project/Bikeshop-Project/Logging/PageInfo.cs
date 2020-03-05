using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Logging
{
    public class PageInfo
    {
        [Key]
        public string Id { get; set; }
        public DateTime TIME_STAMP { get; set; }
        public string PageTitle { get; set; }
        public string UserName { get; set; }
    }
}
