using Blog_Solution.Web.Framework;
using System.ComponentModel.DataAnnotations;

namespace Blog_Solution.Web.Models.Account
{
    public class LoginModel
    {
        [Required]
        [ResourceDisplayName("Account.LoginName")]
        public string LoginName { get; set; }

        [Required]
        [ResourceDisplayName("Account.Password")]
        public string Password { get; set; }

        [ResourceDisplayName("Account.RememberMe")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}