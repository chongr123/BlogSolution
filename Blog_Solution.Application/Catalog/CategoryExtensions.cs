using Blog_Solution.Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Solution.Catalog
{
    /// <summary>
    /// 类别扩展
    /// </summary>
    public static class CategoryExtensions
    {

        public static IList<Category> GetCategoryBreadCrumb(this Category category,
                ICategoryService categoryService,
                bool showHidden = false)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            var result = new List<Category>();

            var alreadyProcessedCategoryIds = new List<int>();

            while (category != null && //not null
                !category.IsDeleted && //not deleted
                (showHidden || category.Enabled) && //published
                !alreadyProcessedCategoryIds.Contains(category.Id)) //prevent circular references
            {
                result.Add(category);

                alreadyProcessedCategoryIds.Add(category.Id);

                category = categoryService.GetCagegoryById(category.ParentId);
            }
            result.Reverse();
            return result;
        }

        public static string GetFormattedBreadCrumb(this Category category,
                                    IList<Category> allCategories,
                                    string separator = ">>")
        {
            string result = string.Empty;

            var breadcrumb = GetCategoryBreadCrumb(category, allCategories, true);
            for (int i = 0; i <= breadcrumb.Count - 1; i++)
            {
                var categoryName = breadcrumb[i].Name;
                result = String.IsNullOrEmpty(result)
                    ? categoryName
                    : string.Format("{0} {1} {2}", result, separator, categoryName);
            }

            return result;
        }

        public static IList<Category> GetCategoryBreadCrumb(this Category category,
                                    IList<Category> allCategories,
                                    bool showHidden = false)
        {
            if (category == null)
                throw new ArgumentNullException("category");

            var result = new List<Category>();

            var alreadyProcessedCategoryIds = new List<int>();

            while (category != null && //not null
                !category.IsDeleted && //not deleted
                (showHidden || category.Enabled) && //published
                !alreadyProcessedCategoryIds.Contains(category.Id)) //prevent circular references
            {
                result.Add(category);

                alreadyProcessedCategoryIds.Add(category.Id);

                category = (from c in allCategories
                            where c.Id == category.ParentId
                            select c).FirstOrDefault();
            }
            result.Reverse();
            return result;
        }

    }
}
