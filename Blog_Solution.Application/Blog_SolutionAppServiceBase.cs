using Abp.Application.Services;

namespace Blog_Solution
{
    /// <summary>
    /// Derive your application services from this class.
    /// </summary>
    public abstract class Blog_SolutionAppServiceBase : ApplicationService
    {
        protected Blog_SolutionAppServiceBase()
        {
            LocalizationSourceName = Blog_SolutionConsts.LocalizationSourceName;
        }
    }
}