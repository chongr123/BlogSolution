using System.Data.Entity;
using System.Reflection;
using Abp.EntityFramework;
using Abp.Modules;
using Blog_Solution.EntityFramework;

namespace Blog_Solution
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(Blog_SolutionCoreModule))]
    public class Blog_SolutionDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<Blog_SolutionDbContext>(null);
        }
    }
}
