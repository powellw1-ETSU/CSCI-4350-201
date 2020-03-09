using System;
using System.ComponentModel.DataAnnotations;

namespace Bikeshop_Project.LoggerModels
{
    public class PageInfo
    {
        [Key]
        public int Id { get; private set; }
        public DateTime TIME_STAMP { get; private set; }
        public string PageTitle { get; private set; }
        public string UserName { get; private set; }

        public PageInfo(int Id, DateTime TIME_STAMP, string PageTitle, string UserName)
        {
            this.Id = Id;
            this.TIME_STAMP = TIME_STAMP;
            this.PageTitle = PageTitle;
            this.UserName = UserName;
        }
    }
}
