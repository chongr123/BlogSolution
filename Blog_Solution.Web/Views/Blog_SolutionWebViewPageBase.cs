using Abp.Web.Mvc.Views;

namespace Blog_Solution.Web.Views
{
    public abstract class Blog_SolutionWebViewPageBase : Blog_SolutionWebViewPageBase<dynamic>
    {

    }

    public abstract class Blog_SolutionWebViewPageBase<TModel> : AbpWebViewPage<TModel>
    {
        protected Blog_SolutionWebViewPageBase()
        {
            LocalizationSourceName = Blog_SolutionConsts.LocalizationSourceName;
        }
    }
}