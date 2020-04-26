using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.LoggerModels
{
    /// <summary>
    /// This class will hold general log information about a user session.
    /// </summary>
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


        /// <summary>
        /// Copy Constructor
        /// </summary>
        /// <param name="TIME_STAMP">when log was sent to the server</param>
        /// <param name="UserName">username of user for this session</param>
        /// <param name="TimeLoggedIn">time the user logged in to our service</param>
        /// <param name="TimeLoggedOut">time the user logged out of our servive</param>
        /// <param name="NumberOfPageViews">number of pages clicked by user</param>
        /// <param name="PageTitle">title of page exited on</param>
        public Logs(string TIME_STAMP, string UserName, DateTime TimeLoggedIn, DateTime TimeLoggedOut, int NumberOfPageViews, string PageTitle)
        {
            this.timeStamp = TIME_STAMP;
            this.userName = UserName;
            this.timeLoggedIn = TimeLoggedIn.ToString();
            this.timeLoggedOut = TimeLoggedOut.ToString();
            this.numberOfPageViews = NumberOfPageViews.ToString();
            this.sessionDuration = (TimeLoggedOut - TimeLoggedIn).ToString();
            this.pageTitle = PageTitle;
        }

        /// <summary>
        /// Empty default constructor. Used to create a Logs object for a user log in session. Data will be filled as necessary.
        /// </summary>
        public Logs()
        {

        }

        #region setters
        public void setUserName(string userName)
        {
            this.userName = userName;
        }

        public void setTimeStamp(string timeStamp)
        {
            this.timeStamp = timeStamp;
        }

        public void setTimeLoggedIn(string timeLoggedIn)
        {
            this.timeLoggedIn = timeLoggedIn;
        }

        public void setTimeLoggedOut(string timeLoggedOut)
        {
            this.timeLoggedOut = timeLoggedOut;
        }

        public void setNumberOfPageViews(string numPageViews)
        {
            this.numberOfPageViews = numPageViews;
        }

        public void setSessionDuration(string sessionDuration)
        {
            this.sessionDuration = sessionDuration;
        }

        public void setPageTitle()
        {
            this.pageTitle = "Bicycles";
        }
        #endregion
    }
}
