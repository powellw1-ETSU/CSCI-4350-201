using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.LoggerModels
{
    public class User
    {
        [Key]
        public string id { get; private set; }
        public string userName { get; private set; }

        public User(string userName)
        {
            this.userName = userName;
        }
    }
}
