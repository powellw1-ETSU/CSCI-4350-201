using Bikeshop_Project.LoggerModels;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Bikeshop_Project
{
    /// <summary>
    /// This class is used for Logging functionality of our program. Calls to this class's static methods
    /// will send data to the Monitoring Team's API.
    /// </summary>
    public static class Logger
    {
        private static readonly HttpClient client = new HttpClient();
        private static readonly string baseUri = "https://monitoringteamapi.azurewebsites.net/api";
        private static readonly string pageExtension = "pages";
        private static readonly string logsExtension = "logs";
        private static readonly string userExtension = "applicationusers";
        private static readonly string orderExtension = "orders";

        private static Logs sessionLogs;
        private static DateTime loggedIn;
        private static bool UserLoggedIn = false;
        private static string userName;

        public static int numberofPageViews;


        /// <summary>
        /// Used to log PageInfo
        /// </summary>
        /// <param name="page"></param>
        public static async void logPage(PageInfo page)
        {
            string uri = $"{baseUri}/{pageExtension}";
            var json = JsonConvert.SerializeObject(page);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(uri, content);
            Console.WriteLine("Hello");
        }

        /// <summary>
        /// Used to log general information about a User's session
        /// </summary>
        /// <param name="generalLog"></param>
        public static async void logLogs(Logs generalLog)
        {
            string uri = $"{baseUri}/{logsExtension}";
            var json = JsonConvert.SerializeObject(generalLog);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync(uri, content);
        }

        /// <summary>
        /// Used to log information about the user
        /// </summary>
        /// <param name="user"></param>
        public static async void logUsers(User user)
        {
            string uri = $"{baseUri}/{userExtension}";
            var json = JsonConvert.SerializeObject(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync(uri, content);
        }
        
        /// <summary>
        /// Used to log information about a customer order
        /// </summary>
        /// <param name="orderInfo"></param>
        public static async void logOrders(Orders orderInfo)
        {
            string uri = $"{baseUri}/{orderExtension}";
            var json = JsonConvert.SerializeObject(orderInfo);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            await client.PostAsync(uri, content);
        }

        #region General Session Logging
        /// <summary>
        /// When a user logs in and/or registers for our application, begin a log session
        /// </summary>
        /// <param name="userName">name of user</param>
        /// <param name="timeLoggedIn">time user logged into the application</param>
        public static void createLogsSession(string userName, DateTime timeLoggedIn)
        {
            // Create sessionLogs session
            sessionLogs = new Logs();
            UserLoggedIn = true;

            // Assign private fields values
            loggedIn = timeLoggedIn;
            Logger.userName = userName;
            numberofPageViews = 0;  // set number of page views to 0 intially.

            // Assign starting session information
            sessionLogs.setUserName(userName);
            sessionLogs.setTimeLoggedIn(timeLoggedIn.ToString());
        }

        /// <summary>
        /// When the user logs out of our application, end the log session and record the information
        /// </summary>
        /// <param name="timeLoggedOut">time user logged out of the application</param>
        public static void endLogsSession(DateTime timeLoggedOut)
        {
            if (UserLoggedIn)
            {
                // Create timespan object to represent session duration
                TimeSpan duration = timeLoggedOut - loggedIn;

                // set remaining info for logs for this session
                sessionLogs.setTimeStamp(DateTime.Now.ToString());
                sessionLogs.setTimeLoggedOut(timeLoggedOut.ToString());
                sessionLogs.setNumberOfPageViews(numberofPageViews.ToString());
                sessionLogs.setSessionDuration(duration.ToString());
                sessionLogs.setPageTitle();

                Logger.logLogs(sessionLogs); // Send log data to the monitoring team
            }
        }
        #endregion

        #region Page Click Logging

        /// <summary>
        /// Each time a page is clicked (when a user is logged in), this method is called
        /// to log the page click
        /// </summary>
        /// <param name="pageTitle">name of page clicked</param>
        public static void LogPageClick(string pageTitle)
        {
            PageInfo pageClick = new PageInfo(DateTime.Now.ToString(), pageTitle, Logger.userName);
            Logger.logPage(pageClick);
        }

        #endregion

        #region User logged in status
        /// <summary>
        /// Sets UserLoggedIn to true. Only called when log in is successful.
        /// </summary>
        public static void setUserLogInTrue()
        {
            UserLoggedIn = true; 
        }

        /// <summary>
        /// Sets UserLoggedIn to false. Only called when a user logs out
        /// </summary>
        public static void setUserLogInFalse()
        {
            UserLoggedIn = false;
        }

        /// <summary>
        /// Used to indicate if a user is currently logged in
        /// </summary>
        /// <returns>returns true if user has logged in. False if not</returns>
        public static bool returnUserLogInStatus()
        {
            return UserLoggedIn;
        }
        #endregion
    }
}
