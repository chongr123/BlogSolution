using Abp.Application.Services;
using Blog_Solution.Customers.Dto;
using Microsoft.AspNet.Identity;

namespace Blog_Solution.Customers
{
    public class CustomerManager : UserManager<Customer, int>, IApplicationService
    {
        public CustomerManager(IUserStore<Customer, int> store) : base(store)
        {
        }
    }
}
