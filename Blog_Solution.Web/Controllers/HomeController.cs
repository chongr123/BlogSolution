using System.Web.Mvc;

namespace Blog_Solution.Web.Controllers
{
    public class HomeController : Blog_SolutionControllerBase
    {
        public ActionResult Index()
        {
            return View();
        }
	}
}