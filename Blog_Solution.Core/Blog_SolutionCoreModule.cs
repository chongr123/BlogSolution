using System.Reflection;
using Abp.Modules;

namespace Blog_Solution
{
    public class Blog_SolutionCoreModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
