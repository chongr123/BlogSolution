using Blog_Solution.EntityFramework;
using System.Linq;

namespace Blog_Solution.Migrations.SeedData
{
    public class DefaultCategoryData
    {
        private readonly Blog_SolutionDbContext _context;

        public DefaultCategoryData(Blog_SolutionDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateCategory();
        }

        private void CreateCategory()
        {
            var netMvc = _context.Category.FirstOrDefault(r => r.Name == "NET Mvc");
            if (netMvc == null)
                netMvc = new Domain.Catalogs.Category
                {
                    Name = "NET Mvc",
                    Description = "Net Mvc技术",
                    Enabled = true,
                    DisplayOrder = 1,
                    IsDeleted = false,
                    ParentId = 0,

                };
            _context.Category.Add(netMvc);
            _context.SaveChanges();

            var winFrom = _context.Category.FirstOrDefault(r => r.Name == "NET WinFrom");
            if (winFrom == null)
                winFrom = new Domain.Catalogs.Category
                {
                    Name = "NET WinFrom",
                    Description = "NET WinFrom",
                    Enabled = true,
                    DisplayOrder = 2,
                    IsDeleted = false,
                    ParentId = 0,

                };
            _context.Category.Add(winFrom);
            _context.SaveChanges();

            var core = _context.Category.FirstOrDefault(r => r.Name == "NET Core");
            if (core == null)
                core = new Domain.Catalogs.Category
                {
                    Name = "NET Core",
                    Description = "NET Core",
                    Enabled = true,
                    DisplayOrder = 3,
                    IsDeleted = false,
                    ParentId = 0,

                };
            _context.Category.Add(core);
            _context.SaveChanges();
        }
        

    }
}
