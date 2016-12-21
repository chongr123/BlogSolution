using Blog_Solution.Web.Framework;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Blog_Solution.Web.Models.Catalogs
{
    public class CategoryListModel
    {
        public CategoryListModel()
        {
            this.AvailableCategories = new List<SelectListItem>();
            this.ParentIds = new List<int>();
        }
        [ResourceDisplayName("Common.Keywords")]
        public string Keywords { get; set; }

        [ResourceDisplayName("Customers.CustomerRoles")]
        [UIHint("MultiSelect")]
        public List<int> ParentIds { get; set; }
        
        public IList<SelectListItem> AvailableCategories { get; set; }
    }
}