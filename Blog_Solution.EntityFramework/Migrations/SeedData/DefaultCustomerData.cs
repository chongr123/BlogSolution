using Blog_Solution.EntityFramework;
using System.Linq;

namespace Blog_Solution.Migrations.SeedData
{

    public class DefaultCustomerData
    {
        private readonly Blog_SolutionDbContext _context;

        public DefaultCustomerData(Blog_SolutionDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateCustomerRole();
            CreateCustomer();
        }

        private void CreateCustomerRole()
        {
            var adminRole = _context.CustomerRole.FirstOrDefault(r => r.RoleName == "系统管理员");
            if (adminRole == null)
                adminRole = new Domain.Customers.CustomerRole
                {
                    DisplayOrder = 1,
                    Enabled = true,
                    IsAdmin = true,
                    ParentId = 0,
                    RoleName = "系统管理员",
                    IsDefault = false,
                };
            _context.CustomerRole.Add(adminRole);
            _context.SaveChanges();

            var defaultRole = _context.CustomerRole.FirstOrDefault(r => r.RoleName == "普通会员");
            if (defaultRole == null)
                defaultRole = new Domain.Customers.CustomerRole
                {
                    DisplayOrder = 1,
                    Enabled = true,
                    IsAdmin = false,
                    ParentId = 0,
                    RoleName = "普通会员",
                    IsDefault = true,
                };
            _context.CustomerRole.Add(defaultRole);
            _context.SaveChanges();
        }

        private void CreateCustomer()
        {
            var admin = _context.Customer.FirstOrDefault(e => e.LoginName == "admin");
            if (admin == null)
            {
                var rd = Common.CommonHelper.GenerateCode(length: 8);
                admin = new Domain.Customers.Customer
                {
                    LoginName = "admin",
                    CustomerRoleId = _context.CustomerRole.FirstOrDefault(r => r.RoleName == "系统管理员").Id,
                    Email = "admin@admin.com",
                    Mobile = "18012341234",
                    Password = Common.CommonHelper.CreatePasswordHash("admin", rd),
                    PasswordSalt = rd,
                    Deleted = false,
                    LastIpAddress = "127.0.0.1",
                };
            }

            _context.Customer.Add(admin);
            _context.SaveChanges();

        }
        
    }
}
