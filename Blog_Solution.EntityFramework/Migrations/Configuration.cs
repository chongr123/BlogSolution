using Blog_Solution.Migrations.SeedData;
using System.Data.Entity.Migrations;

namespace Blog_Solution.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Blog_Solution.EntityFramework.Blog_SolutionDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "Blog_Solution";
        }

        protected override void Seed(Blog_Solution.EntityFramework.Blog_SolutionDbContext context)
        {
            // This method will be called every time after migrating to the latest version.
            // You can add any seed data here...
            new InitialHostDbBuilder(context).Create();
        }
    }
}
