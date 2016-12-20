using System;
using System.Threading.Tasks;
using Abp.Application.Services;
using Microsoft.AspNet.Identity;
using Blog_Solution.Customers.Dto;

namespace Blog_Solution.Customers
{
    /// <summary>
    /// 用户仓储
    /// </summary>
    public class CustomerStore : IUserStore<Customer,int>, IApplicationService
    {
        #region Fields && Ctor
        private readonly ICustomerService _customerService;

        public CustomerStore(ICustomerService customerService)
        {
            this._customerService = customerService;
        }

        #endregion

        #region Method

        public Task CreateAsync(Customer user)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Customer user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<Customer> FindByIdAsync(int userId)
        {
            var customer = _customerService.GetCustomerById(userId);

            return new Customer
            {
                Id = customer.Id,
                CreationTime = customer.CreationTime,
                CustomerRoleId = customer.CustomerRoleId,
                Deleted = customer.Deleted,
                Email = customer.Email,
                LastIpAddress = customer.LastIpAddress,
                LastModificationTime = customer.LastModificationTime,
                LoginName = customer.LoginName,
                Mobile = customer.Mobile,
                Password = customer.Password,
                PasswordSalt = customer.PasswordSalt,
                PasswordFormat = customer.PasswordFormat,
                PasswordFormatId = customer.PasswordFormatId,
                UserName =customer.LoginName
            };
        }

        public async Task<Customer> FindByNameAsync(string userName)
        {
            var customer = _customerService.GetCustomerByLoginName(userName);
            return new Customer
            {
                Id = customer.Id,
                CreationTime = customer.CreationTime,
                CustomerRoleId = customer.CustomerRoleId,
                Deleted = customer.Deleted,
                Email = customer.Email,
                LastIpAddress = customer.LastIpAddress,
                LastModificationTime = customer.LastModificationTime,
                LoginName = customer.LoginName,
                Mobile = customer.Mobile,
                Password = customer.Password,
                PasswordSalt = customer.PasswordSalt,
                PasswordFormat = customer.PasswordFormat,
                PasswordFormatId = customer.PasswordFormatId,
                UserName = customer.LoginName
            };
        }

        public Task UpdateAsync(Customer user)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
