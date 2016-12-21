using System;
using System.Collections.Generic;
using System.Linq;
using Abp.Application.Services.Dto;
using Blog_Solution.Domain.Catalogs;
using Abp.Domain.Repositories;

namespace Blog_Solution.Catalog
{
    public class BlogService : Blog_SolutionAppServiceBase, IBlogService
    {


        #region Fields && Ctor
        private readonly IRepository<Blog> _blogRepository;
        public BlogService(IRepository<Blog> blogRepository)
        {
            this._blogRepository = blogRepository;
        }

        #endregion

        #region Method
        public void DeleteBlog(Blog blog)
        {
            if (blog == null)
                throw new NotImplementedException("blog");
            blog.IsDeleted = true;
            UpdateBlog(blog);
        }

        public IPagedResult<Blog> GetAllBlogs(string keywords = null, 
                                            DateTime? CreatedFrom = null, DateTime? CreatedTo = null, 
                                            int[] categoryIds = null, bool showHidden = false,
                                            int pageIndex = 0, int pageSize = int.MaxValue)
        {
            var query = _blogRepository.GetAll();
            if (!String.IsNullOrWhiteSpace(keywords))
                query = query.Where(c => c.BolgTitle.Contains(keywords) ||
                                     c.Author.Contains(keywords) ||
                                     c.Content.Contains(keywords) ||
                                     c.Description.Contains(keywords));

            if (categoryIds != null && categoryIds.Count() > 0)
                query = query.Where(c => categoryIds.Contains(c.CategoryId));

            if (!showHidden)
                query = query.Where(c => !c.IsDeleted && c.Audit);

            if (CreatedFrom.HasValue)
                query = query.Where(c => CreatedFrom.Value <= c.CreationTime);
            if (CreatedTo.HasValue)
                query = query.Where(c => CreatedTo.Value >= c.CreationTime);            

            query = query.OrderByDescending(c => c.CreationTime);
            return new PagedResult<Blog>(query, pageIndex,pageSize);
        }

        public Blog GetBlogById(int blogId)
        {
            if (blogId == 0)
                return null;
            return _blogRepository.Get(blogId);
        }

        public IList<Blog> GetBlogs(int[] categoryIds, bool showHidden = false)
        {
            var query = from b in _blogRepository.GetAll()
                        where categoryIds.Contains(b.CategoryId) && (showHidden || (b.Audit && !b.IsDeleted))
                        orderby b.CreationTime descending
                        select b;
            return query.ToList();
        }

        public void InsertBlog(Blog blog)
        {
            if (blog == null)
                throw new NotImplementedException("blog");
            _blogRepository.Insert(blog);
        }

        public void UpdateBlog(Blog blog)
        {
            if (blog == null)
                throw new NotImplementedException("blog");
            _blogRepository.Update(blog);
        }
        #endregion
    }
}
