using Blog_Solution.EntityFramework;
using EntityFramework.DynamicFilters;

namespace Blog_Solution.Migrations.SeedData
{
    public class InitialHostDbBuilder
    {
        private readonly Blog_SolutionDbContext _context;

        public InitialHostDbBuilder(Blog_SolutionDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            _context.DisableAllFilters();
            new DefaultCustomerData(_context).Create();
            new DefaultCategoryData(_context).Create();
        }
    }
}
