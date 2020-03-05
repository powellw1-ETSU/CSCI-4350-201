using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Logging
{
    public class User
    {
        [Key]
        public string UserName { get; set; }
        public string IPAddress { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
    }
}
