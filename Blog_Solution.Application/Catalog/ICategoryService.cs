using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Blog_Solution.Domain.Catalogs;
using System.Collections.Generic;

namespace Blog_Solution.Catalog
{
    public interface ICategoryService: IApplicationService
    {
        /// <summary>
        /// 新增类别
        /// </summary>
        /// <param name="category"></param>
        void InsertCategory(Category category);

        /// <summary>
        /// 更新类别
        /// </summary>
        /// <param name="category"></param>
        void UpdateCategory(Category category);

        /// <summary>
        /// 软删除
        /// </summary>
        /// <param name="category"></param>
        void DeleteCategory(Category category);

        /// <summary>
        /// 根据父节点获取类别
        /// </summary>
        /// <param name="parentId"></param>
        /// <returns></returns>
        IList<Category> GetCagegoriesByParentId(int parentId);

        /// <summary>
        /// 根据主键获取类别
        /// </summary>
        /// <param name="categoryId"></param>
        /// <returns></returns>
        Category GetCagegoryById(int categoryId);


        /// <summary>
        /// 查询类别
        /// </summary>
        /// <param name="keywords"></param>
        /// <param name="showHidden"></param>
        /// <param name="parentIds"></param>
        /// <param name="pageIndex"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        IPagedResult<Category> GetAllCategories(string keywords = "", bool showHidden = false,
            List<int> parentIds = null, int pageIndex = 0, int pageSize = int.MaxValue);
    }
}
