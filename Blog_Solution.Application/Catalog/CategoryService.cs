using Abp.Domain.Repositories;
using Blog_Solution.Domain.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services.Dto;

namespace Blog_Solution.Catalog
{

    public class CategoryService : Blog_SolutionAppServiceBase, ICategoryService
    {
        #region Fields && Ctor
        private readonly IRepository<Category> _categoryRepository;
        public CategoryService(IRepository<Category> categoryRepository)
        {
            this._categoryRepository = categoryRepository;
        }

        #endregion

        #region Method
        
        public void DeleteCategory(Category category)
        {
            if (category == null)
                throw new NotImplementedException("Category");
            category.IsDeleted = true;
            UpdateCategory(category);
        }

        public IPagedResult<Category> GetAllCategories(string keywords = "", bool showHidden = false,
            List<int> parentIds = null, int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _categoryRepository.GetAll();

            if (!String.IsNullOrWhiteSpace(keywords))
                query = query.Where(c => c.Name.Contains(keywords) ||
                                    c.Description.Contains(keywords));

            if (!showHidden)
                query = query.Where(c => c.Enabled && !c.IsDeleted);

            if (parentIds != null && parentIds.Count > 0)
                query = query.Where(c => parentIds.Contains(c.ParentId));

            query = query.OrderBy(c => c.DisplayOrder);
            
            return new PagedResult<Category>(query, pageIndex, pageSize);
        }

        public IList<Category> GetCagegoriesByParentId(int parentId)
        {
            var query = _categoryRepository.GetAll();
            query = query.Where(c => c.ParentId == parentId);
            return query.ToList();
        }

        public Category GetCagegoryById(int categoryId)
        {
            if (categoryId == 0)
                return null;
            return _categoryRepository.Get(categoryId);
        }

        public void InsertCategory(Category category)
        {
            if (category == null)
                throw new NotImplementedException("Category");
            _categoryRepository.Insert(category);
        }

        public void UpdateCategory(Category category)
        {
            if (category == null)
                throw new NotImplementedException("Category");
            _categoryRepository.Update(category);
        }
        
        #endregion
    }
}
