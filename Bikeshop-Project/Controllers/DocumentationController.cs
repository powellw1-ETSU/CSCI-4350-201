using Microsoft.AspNetCore.Mvc;

namespace Bikeshop_Project.Controllers
{
    public class DocumentationController : Controller
    {
        /// <summary>
        /// Redirects the user to the location of our API Documentation
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return Redirect("https://documenter.getpostman.com/view/10667180/SzYaVyDD?version=latest");
        }
    }
}