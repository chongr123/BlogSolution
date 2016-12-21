using System;
using System.Collections.Generic;
using System.Linq;
using Blog_Solution.Domain.Catalogs;
using Abp.Domain.Repositories;

namespace Blog_Solution.Catalog
{
    public class BlogReviewService : Blog_SolutionAppServiceBase, IBlogReviewService
    {

        #region Fields && Ctor
        private readonly IRepository<BlogReview> _reviewRepository;
        public BlogReviewService(IRepository<BlogReview> reviewRepository)
        {
            this._reviewRepository = reviewRepository;
        }
        
        #endregion

        #region  Method
        public void ClearReview(int blogId)
        {
            _reviewRepository.Delete(v => v.BlogId == blogId);
        }

        public void DeleteReview(int reviewId)
        {
            _reviewRepository.Delete(reviewId);
        }

        public IList<BlogReview> GetBlogReviews(int blogId)
        {
            var query = from r in _reviewRepository.GetAll()
                        where r.BlogId == blogId
                        orderby r.CreationTime descending
                        select r;
            return query.ToList();
        }

        public void InsertReview(BlogReview review)
        {
            if (review == null)
                throw new NotImplementedException("review");
            _reviewRepository.Insert(review);
        }

        public void UpdateReview(BlogReview review)
        {
            if (review == null)
                throw new NotImplementedException("review");
            _reviewRepository.Update(review);
        }
        #endregion
    }
}
