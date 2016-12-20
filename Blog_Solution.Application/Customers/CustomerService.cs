using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Application.Services.Dto;
using Blog_Solution.Domain.Customers;
using Abp.Domain.Repositories;

namespace Blog_Solution.Customers
{
    public class CustomerService : Blog_SolutionAppServiceBase, ICustomerService
    {
        #region Fields && Ctor
        private readonly IRepository<Customer> _customerRepository;

        public CustomerService(IRepository<Customer> customerRepository)
        {
            this._customerRepository = customerRepository;
        }

        #endregion

        #region Method
        public IPagedResult<Customer> GetAllCustomers(DateTime? createdFrom = null, DateTime? createdTo = null, 
            int[] customerRoleIds = null, string email = null, string loginName = null, string mobile = null,
            int pageIndex = 0, int pageSize = int.MaxValue)
        {

            var query = _customerRepository.GetAll();
            if (createdFrom.HasValue)
                query = query.Where(c => createdFrom.Value <= c.CreationTime);
            if (createdTo.HasValue)
                query = query.Where(c => createdTo.Value >= c.CreationTime);

            if (!String.IsNullOrWhiteSpace(mobile))
                query = query.Where(c => c.Mobile.Contains(mobile));

            query = query.Where(c => !c.Deleted);

            if (customerRoleIds != null && customerRoleIds.Length > 0)
                query = query.Where(c => customerRoleIds.Contains(c.CustomerRoleId));
            if (!String.IsNullOrWhiteSpace(email))
                query = query.Where(c => c.Email.Contains(email));
            if (!String.IsNullOrWhiteSpace(loginName))
                query = query.Where(c => c.LoginName.Contains(loginName));
            

            query = query.OrderByDescending(c => c.CreationTime);

            var customers = new PagedResult<Customer>(query, pageIndex, pageSize);
            return customers;
        }

        public Customer GetCustomerByEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email))
                return null;

            var query = from c in _customerRepository.GetAll()
                        orderby c.Id
                        where c.Email == email
                        select c;
            var customer = query.FirstOrDefault();
            return customer;
        }

        public Customer GetCustomerById(int customerId)
        {
            return _customerRepository.Get(customerId);
        }

        public Customer GetCustomerByLoginName(string loginName)
        {
            if (string.IsNullOrWhiteSpace(loginName))
                return null;

            var query = from c in _customerRepository.GetAll()
                        orderby c.Id
                        where c.LoginName == loginName
                        select c;
            var customer = query.FirstOrDefault();
            return customer;
        }

        public Customer GetCustomerByMobile(string mobile)
        {
            if (string.IsNullOrWhiteSpace(mobile))
                return null;

            var query = from c in _customerRepository.GetAll()
                        orderby c.Id
                        where c.Mobile == mobile
                        select c;
            var customer = query.FirstOrDefault();
            return customer;
        }

        public void InsertCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            _customerRepository.Insert(customer);
            
        }

        public void UpdateCustomer(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException("customer");

            _customerRepository.Update(customer);
        }
        #endregion
    }
}
