using Abp.Web.Mvc.Views;

namespace Blog_Solution.Web.Views
{
    public abstract class Blog_SolutionWebViewPageBase : Blog_SolutionWebViewPageBase<dynamic>
    {

    }

    public abstract class Blog_SolutionWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        public const int defaultGridPageSize = 20;
        public const string gridPageSizes = "20,40,60";

        protected Blog_SolutionWebViewPageBase()
        {
            LocalizationSourceName = Blog_SolutionConsts.LocalizationSourceName;
        }
        
    }
}