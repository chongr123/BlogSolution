using System.Web.Mvc;

namespace Blog_Solution.Web.Controllers
{
    public class AboutController : Blog_SolutionControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}