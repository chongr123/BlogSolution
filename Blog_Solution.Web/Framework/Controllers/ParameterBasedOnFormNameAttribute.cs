using System;
using System.Linq;
using System.Web.Mvc;

namespace Blog_Solution.Web.Framework.Controllers
{

    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class ParameterBasedOnFormNameAttribute : FilterAttribute, IActionFilter
    {
        private readonly string _name;
        private readonly string _actionParameterName;

        public ParameterBasedOnFormNameAttribute(string name, string actionParameterName)
        {
            this._name = name;
            this._actionParameterName = actionParameterName;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            filterContext.ActionParameters[_actionParameterName] = filterContext.RequestContext
                .HttpContext.Request.Form.AllKeys.Any(x => x.Equals(_name));
        }
    }
}