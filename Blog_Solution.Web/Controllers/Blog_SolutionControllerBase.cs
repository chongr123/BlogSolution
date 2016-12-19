using Abp.Web.Mvc.Controllers;

namespace Blog_Solution.Web.Controllers
{
    /// <summary>
    /// Derive all Controllers from this class.
    /// </summary>
    public abstract class Blog_SolutionControllerBase : AbpController
    {
        protected Blog_SolutionControllerBase()
        {
            LocalizationSourceName = Blog_SolutionConsts.LocalizationSourceName;
        }
    }
}