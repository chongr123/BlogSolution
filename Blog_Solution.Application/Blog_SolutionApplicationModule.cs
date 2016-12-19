using System.Reflection;
using Abp.Modules;

namespace Blog_Solution
{
    [DependsOn(typeof(Blog_SolutionCoreModule))]
    public class Blog_SolutionApplicationModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
