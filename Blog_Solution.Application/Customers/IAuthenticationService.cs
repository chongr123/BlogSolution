using Abp.Application.Services;
using Blog_Solution.Customers.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Solution.Customers
{
    /// <summary>
    /// 用户认证服务
    /// </summary>
    public interface IAuthenticationService: IApplicationService
    {

        /// <summary>
        /// 验证用户
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        CustomerLoginResults ValidateCustomer(string loginName, string password);
    }
}
