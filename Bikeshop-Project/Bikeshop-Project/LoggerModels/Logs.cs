using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.LoggerModels
{
    public class Logs
    {
        [Key]
        public int Id { get; private set; }
        public DateTime TIME_STAMP { get; private set; }
        public string UserName { get; private set; }
        public DateTime TimeLoggedIn { get; private set; }
        public DateTime TimeLoggedOut { get; private set; }
        public int NumberOfPageViews { get; private set; }
        public TimeSpan SessionDuration { get; private set; }
        public string PageTitle { get; private set; }

        public Logs(int Id, DateTime TIME_STAMP, string UserName, DateTime TimeLoggedIn, DateTime TimeLoggedOut, int NumberOfPageViews, TimeSpan SessionDuration, string PageTitle)
        {
            this.Id = Id;
            this.TIME_STAMP = TIME_STAMP;
            this.UserName = UserName;
            this.TimeLoggedIn = TimeLoggedIn;
            this.TimeLoggedOut = TimeLoggedOut;
            this.NumberOfPageViews = NumberOfPageViews;
            this.SessionDuration = SessionDuration;
            this.PageTitle = PageTitle;
        }
    }
}
