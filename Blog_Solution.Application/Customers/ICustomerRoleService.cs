using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Blog_Solution.Domain.Customers;
using System.Collections.Generic;

namespace Blog_Solution.Customers
{
    public interface ICustomerRoleService: IApplicationService
    {
        /// <summary>
        /// 获取所有权限
        /// </summary>
        /// <param name="keywords">关键字</param>
        /// <param name="showHidden">是否显示隐藏的值</param>
        /// <param name="isAdmin">是否管理员</param>
        /// <param name="parentIds">父节点</param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IPagedResult<CustomerRole> GetAllRoles(string keywords = "", bool showHidden = false,
            bool? isAdmin = null, List<int> parentIds = null, int pageIndex = 0, int pageSize = int.MaxValue);

        /// <summary>
        /// 获取用户角色
        /// </summary>
        /// <param name="customerRoleId"></param>
        /// <returns></returns>
        CustomerRole GetCustomerRoleById(int customerRoleId);

        /// <summary>
        /// 新增角色
        /// </summary>
        /// <param name="role"></param>
        void InsertCustomerRole(CustomerRole role);

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="role"></param>
        void UpdateCustomerRole(CustomerRole role);

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="customerRoleId"></param>
        void DeleteCustomerRole(int customerRoleId);
        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="role"></param>
        void DeleteCustomerRole(CustomerRole role);
    }
}
