using Abp.Web.Mvc.Controllers;
using Abp.Web.Mvc.Controllers.Results;
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
    }
}