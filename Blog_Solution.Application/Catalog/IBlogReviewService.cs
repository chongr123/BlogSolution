using Abp.Application.Services;
using Blog_Solution.Domain.Catalogs;
using System.Collections.Generic;

namespace Blog_Solution.Catalog
{
    public interface IBlogReviewService : IApplicationService
    {
        /// <summary>
        /// 新增评论
        /// </summary>
        /// <param name="review"></param>
        void InsertReview(BlogReview review);

        /// <summary>
        /// 更新评论
        /// </summary>
        /// <param name="review"></param>
        void UpdateReview(BlogReview review);

        /// <summary>
        /// 删除评论
        /// </summary>
        /// <param name="reviewId"></param>
        void DeleteReview(int reviewId);

        /// <summary>
        /// 清空博客的评论
        /// </summary>
        /// <param name="blogId"></param>
        void ClearReview(int blogId);
        
        /// <summary>
        /// 根据博客主键获取评论
        /// </summary>
        /// <param name="blogId"></param>
        /// <returns></returns>
        IList<BlogReview> GetBlogReviews(int blogId);
    }
}
