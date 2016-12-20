using Abp.Application.Services.Dto;

namespace Blog_Solution.Web.Framework
{
    public class DeleteConfirmationModel : EntityDto
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string WindowId { get; set; }
    }
}