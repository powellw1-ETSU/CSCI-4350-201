using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.LoggerModels
{
    public class Logs
    {
        [Key]
        public int id { get; private set; }
        public string timeStamp { get; private set; }
        public string userName { get; private set; }
        public string timeLoggedIn { get; private set; }
        public string timeLoggedOut { get; private set; }
        public string numberOfPageViews { get; private set; }
        public string sessionDuration { get; private set; }
        public string pageTitle { get; private set; }

        public Logs(int Id, string TIME_STAMP, string UserName, DateTime TimeLoggedIn, DateTime TimeLoggedOut, int NumberOfPageViews, string PageTitle)
        {
            this.id = Id;
            this.timeStamp = TIME_STAMP;
            this.userName = UserName;
            this.timeLoggedIn = TimeLoggedIn.ToString();
            this.timeLoggedOut = TimeLoggedOut.ToString();
            this.numberOfPageViews = NumberOfPageViews.ToString();
            this.sessionDuration = (TimeLoggedOut - TimeLoggedIn).ToString();
            this.pageTitle = PageTitle;
        }
    }
}
