using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.LoggerModels
{
    public class PageInfo
    {
        [Key]
        public int id { get; private set; }
        public string timeStamp { get; private set; }
        public string pageTitle { get; private set; }
        public string userName { get; private set; }

        public PageInfo(string TIME_STAMP, string PageTitle, string UserName)
        {
            this.timeStamp = TIME_STAMP;
            this.pageTitle = PageTitle;
            this.userName = UserName;
        }
    }
}
