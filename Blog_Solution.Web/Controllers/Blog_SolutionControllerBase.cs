using Abp.Web.Mvc.Controllers;
using Abp.Web.Mvc.Controllers.Results;
using System;
using System.Text;
using System.Web.Mvc;

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

        protected override AbpJsonResult AbpJson(object data, string contentType = null, 
            Encoding contentEncoding = null, JsonRequestBehavior behavior = JsonRequestBehavior.DenyGet,
            bool wrapResult = true, bool camelCase = false, bool indented = false)
        {
            return new AbpJsonResult
            {
                Data = data,
                ContentType = contentType,
                ContentEncoding = contentEncoding,
                JsonRequestBehavior = behavior,
                MaxJsonLength = int.MaxValue,
                CamelCase = camelCase,
                Indented = indented,
            };
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //子节点抛出
            if (filterContext.IsChildAction)
                return;

            var accountControllerName = string.Concat(this.GetType().Namespace, ".", "AccountController");

            string controllerName = filterContext.Controller.ToString();
            //string actionName = filterContext.ActionDescriptor.ActionName;

            if (!controllerName.Equals(accountControllerName, StringComparison.InvariantCultureIgnoreCase) &&
                !filterContext.HttpContext.User.Identity.IsAuthenticated)
            {
                filterContext.Result = new RedirectResult("/Account/Login");
                //filterContext.Result = new RedirectResult(string.Concat("/login?returnUrl=", filterContext.RequestContext.HttpContext.Request.Url.ToString()));
            }

            base.OnActionExecuting(filterContext);
        }
    }
}