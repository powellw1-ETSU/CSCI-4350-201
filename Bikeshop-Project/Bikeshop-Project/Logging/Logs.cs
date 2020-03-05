using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.Logging
{
    public class Logs
    {
        [Key]
        public int Id { get; set; }
        public DateTime TIME_STAMP { get; set; }
        public string UserName { get; set; }
        public DateTime TimeLoggedIn { get; set; }
        public DateTime TimeLoggedOut { get; set; }
        public int NumberOfPageViews { get; set; }
        public TimeSpan SessionDuration { get; set; }
        public string PageTitle { get; set; }
    }
}
