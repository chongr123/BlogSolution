using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Blog_Solution.Domain.Catalogs;
using System;
using System.Collections.Generic;

namespace Blog_Solution.Catalog
{
    public interface IBlogService : IApplicationService
    {
        /// <summary>
        /// 新增博客
        /// </summary>
        /// <param name="blog"></param>
        void InsertBlog(Blog blog);

        /// <summary>
        /// 更新博客
        /// </summary>
        /// <param name="blog"></param>
        void UpdateBlog(Blog blog);

        /// <summary>
        /// 删除博客
        /// </summary>
        /// <param name="blog"></param>
        void DeleteBlog(Blog blog);

        /// <summary>
        /// 根据主键获取博客内容
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        Blog GetBlogById(int blogId);

        /// <summary>
        /// 根据类别信息获取博客内容
        /// </summary>
        /// <param name="categoryIds"></param>
        /// <param name="showHidden"></param>
        /// <returns></returns>
        IList<Blog> GetBlogs(int[] categoryIds, bool showHidden = false);

        /// <summary>
        /// 获取所有博客
        /// </summary>
        /// <param name="keywords">关键字</param>
        /// <param name="CreatedFrom">发布时间</param>
        /// <param name="CreatedTo">发布时间</param>
        /// <param name="categoryIds">所属类别</param>
        /// <param name="showHidden">是否显示隐藏的值</param>
        /// <param name="pagedIndex">当前页</param>
        /// <param name="pageSize">页个数</param>
        /// <returns></returns>
        IPagedResult<Blog> GetAllBlogs(string keywords = null, DateTime? CreatedFrom = null, DateTime? CreatedTo = null,
                                       int[] categoryIds = null, bool showHidden = false, int pageIndex = 0, int pageSize = int.MaxValue);

    }
}