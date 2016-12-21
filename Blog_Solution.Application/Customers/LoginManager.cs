using Abp.Application.Services;
using Blog_Solution.Customers.Dto;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Threading.Tasks;

namespace Blog_Solution.Customers
{

    public class LoginManager : SignInManager<Customer, int>, IApplicationService
    {
        private readonly UserManager<Customer, int> _userManager;
        private readonly IAuthenticationManager _authenticationManager;
        public LoginManager(UserManager<Customer, int> userManager, AuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
            this._userManager = userManager;
            this._authenticationManager = authenticationManager;
        }

        public override Task SignInAsync(Customer user, bool isPersistent, bool rememberBrowser)
        {
            return base.SignInAsync(user, isPersistent, rememberBrowser);
        }

    }
}
