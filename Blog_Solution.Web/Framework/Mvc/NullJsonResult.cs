using Blog_Solution.Common;
using Newtonsoft.Json;
using System;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace Blog_Solution.Web.Framework.Mvc
{

    public class NullJsonResult : JsonResult
    {
        public override void ExecuteResult(ControllerContext context)
        {
            if (context == null)
                throw new ArgumentNullException("context");
            
            var response = context.HttpContext.Response;
            response.ContentType = !String.IsNullOrEmpty(ContentType) ? ContentType : MimeTypes.ApplicationJson;
            if (ContentEncoding != null)
                response.ContentEncoding = ContentEncoding;

            this.Data = null;

            //If you need special handling, you can call another form of SerializeObject below
            var serializedObject = JsonConvert.SerializeObject(Data, Formatting.Indented);
            response.Write(serializedObject);
        }
    }
}