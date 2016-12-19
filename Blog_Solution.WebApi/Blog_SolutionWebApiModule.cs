using System.Reflection;
using Abp.Application.Services;
using Abp.Configuration.Startup;
using Abp.Modules;
using Abp.WebApi;

namespace Blog_Solution
{
    [DependsOn(typeof(AbpWebApiModule), typeof(Blog_SolutionApplicationModule))]
    public class Blog_SolutionWebApiModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            Configuration.Modules.AbpWebApi().DynamicApiControllerBuilder
                .ForAll<IApplicationService>(typeof(Blog_SolutionApplicationModule).Assembly, "app")
                .Build();
        }
    }
}
