using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Blog_Solution.Customers.Dto;
using System;

namespace Blog_Solution.Customers
{
    public interface ICustomerService: IApplicationService
    {
        /// <summary>
        /// 新增用户
        /// </summary>
        /// <param name="customer"></param>
        void InsertCustomer(Customer customer);

        /// <summary>
        /// 更新用户
        /// </summary>
        /// <param name="input"></param>
        void UpdateCustomer(Customer input);

        /// <summary>
        /// 根据主键获取用户
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        Customer GetCustomerById(int customerId);

        /// <summary>
        /// 根据登录名获取用户
        /// </summary>
        /// <param name="loginName"></param>
        /// <returns></returns>
        Customer GetCustomerByLoginName(string loginName);

        /// <summary>
        /// 根据邮箱获取用户
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        Customer GetCustomerByEmail(string email);

        /// <summary>
        /// 根据手机获取用户
        /// </summary>
        /// <param name="mobile"></param>
        /// <returns></returns>
        Customer GetCustomerByMobile(string mobile);

        /// <summary>
        /// 获取所有用户
        /// </summary>
        /// <param name="createdFrom"></param>
        /// <param name="createdTo"></param>
        /// <param name="customerRoleIds"></param>
        /// <param name="email"></param>
        /// <param name="loginName"></param>
        /// <param name="mobile"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IPagedResult<Customer> GetAllCustomers(DateTime? createdFrom = null,
            DateTime? createdTo = null,int[] customerRoleIds = null, 
            string email = null, string loginName = null, string mobile = null,
            int pageIndex = 0, int pageSize = int.MaxValue);
    }
}
