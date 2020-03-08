using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.LoggerModels
{
    public class User
    {
        [Key]
        public string UserName { get; private set; }
        public string IPAddress { get; private set; }
        public string Country { get; private set; }
        public string City { get; private set; }

        public User(string UserName, string IPAddress, string Country, string City)
        {
            this.UserName = UserName;
            this.IPAddress = IPAddress;
            this.Country = Country;
            this.City = City;
        }
    }
}
