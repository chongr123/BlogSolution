using System.Reflection;
using Abp.Modules;
using Blog_Solution.Customers.Dto;
using Blog_Solution.Customers;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;

namespace Blog_Solution
{
    [DependsOn(typeof(Blog_SolutionCoreModule))]
    public class Blog_SolutionApplicationModule : AbpModule
    {
        public override void PostInitialize()
        {
            IocManager.Register<IAuthenticationManager, AuthenticationManager>();
            IocManager.Register<IUserStore<Customer, int>, CustomerStore>();
            IocManager.Register<UserManager<Customer, int>, CustomerManager>();
            //IocManager.Register<SignInManager<Customer, int>, LoginManager>();
            //base.PostInitialize();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
