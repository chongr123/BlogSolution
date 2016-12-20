using System;
using System.Collections.Generic;
using Abp.Application.Services.Dto;
using Blog_Solution.Domain.Customers;
using Abp.Domain.Repositories;
using System.Linq;

namespace Blog_Solution.Customers
{
    public class CustomerRoleService : Blog_SolutionAppServiceBase, ICustomerRoleService
    {

        #region Fields && Ctor
        private readonly IRepository<CustomerRole> _roleRepository;

        public CustomerRoleService(IRepository<CustomerRole> roleRepository)
        {
            this._roleRepository = roleRepository;
        }

        #endregion

        #region Method
        public void DeleteCustomerRole(CustomerRole role)
        {
            if (role.IsDefault)
                throw new NotImplementedException("不能删除默认用户");
            _roleRepository.Delete(role.Id);
        }

        public void DeleteCustomerRole(int customerRoleId)
        {
            _roleRepository.Delete(customerRoleId);
        }

        public IPagedResult<CustomerRole> GetAllRoles(string keywords = "", bool showHidden = false, 
            bool? isAdmin = null, List<int> parentIds = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _roleRepository.GetAll();

            if (!String.IsNullOrWhiteSpace(keywords))
                query = query.Where(r => r.RoleName.Contains(keywords));

            if (parentIds != null)
                query = query.Where(r => parentIds.Contains(r.ParentId));

            if (isAdmin.HasValue)
                query = query.Where(r => r.IsAdmin && isAdmin.Value);

            if (!showHidden)
                query = query.Where(r => r.Enabled);
            
            query = query.OrderBy(c => c.DisplayOrder);
            return new PagedResult<CustomerRole>(query, pageIndex, pageSize);
        }

        public CustomerRole GetCustomerRoleById(int customerRoleId)
        {
            if (customerRoleId == 0)
                return null;
            return _roleRepository.Get(customerRoleId);
        }

        public void InsertCustomerRole(CustomerRole role)
        {
            if (role == null)
                throw new ArgumentNullException("customerRole");
            _roleRepository.Insert(role);
        }

        public void UpdateCustomerRole(CustomerRole role)
        {
            if (role == null)
                throw new ArgumentNullException("customerRole");
            _roleRepository.Update(role);
        }

        #endregion
    }
}
