using Abp.Application.Services.Dto;

namespace Blog_Solution.Customers.Dto
{
    /// <summary>
    /// 登录验证
    /// </summary>
    public class CustomerLoginResults : EntityDto
    {
        public LoginResults Result { get; set; }

        public Customer Customer { get; set; }
    }
}
