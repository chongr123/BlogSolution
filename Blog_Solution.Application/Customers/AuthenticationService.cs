using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Blog_Solution.Customers.Dto;
using Blog_Solution.Security;

namespace Blog_Solution.Customers
{
    /// <summary>
    /// 用户认证服务实现类
    /// </summary>
    public class AuthenticationService : Blog_SolutionAppServiceBase, IAuthenticationService
    {
        #region Fields && Ctor
        private readonly ICustomerService _customerService;
        private readonly IEncryptionService _encryptionService;
        public AuthenticationService(ICustomerService customerService, IEncryptionService encryptionService)
        {
            this._customerService = customerService;
            this._encryptionService = encryptionService;
        }

        #endregion

        #region Method

        
        public CustomerLoginResults ValidateCustomer(string loginName, string password)
        {
            var result = new CustomerLoginResults();
            var customer = _customerService.GetCustomerByLoginName(loginName);

            if (customer == null)
                result.Result = LoginResults.NotRegistered;
            if (customer.Deleted)
                result.Result = LoginResults.Deleted;

            string pwd = _encryptionService.CreatePasswordHash(password, customer.PasswordSalt);
            bool isValid = pwd == customer.Password;
            if (!isValid)
                result.Result = LoginResults.WrongPassword;
            
            result.Result = LoginResults.Successful;
            result.Customer = new Customer {

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
            return result;
        }

        #endregion        
    }
}
