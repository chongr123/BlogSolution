using Blog_Solution.Catalog;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Blog_Solution.Web.Helper
{
    public static class SelectListHelper
    {
        /// <summary>
        /// 获取类别列表
        /// </summary>
        /// <param name="categoryService">Category service</param>
        /// <param name="cacheManager">Cache manager</param>
        /// <param name="showHidden">A value indicating whether to show hidden records</param>
        /// <returns>Category list</returns>
        public static List<SelectListItem> GetCategoryList(ICategoryService categoryService, bool showHidden = false, int currentId = 0)
        {
            var categories = categoryService.GetAllCategories(showHidden: showHidden);
            var categoryListItems = categories.Items
                .Where(c => c.Id != currentId)
                .Select(c => new SelectListItem
                {
                    Text = c.GetFormattedBreadCrumb(categories.Items.ToList()),
                    Value = c.Id.ToString()
                });

            var result = new List<SelectListItem>();
            foreach (var item in categoryListItems)
            {
                result.Add(new SelectListItem
                {
                    Text = item.Text,
                    Value = item.Value
                });
            }

            return result;
        }
    }
}