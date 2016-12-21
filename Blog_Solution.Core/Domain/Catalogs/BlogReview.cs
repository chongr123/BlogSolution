using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blog_Solution.Domain.Catalogs
{
    /// <summary>
    /// 评论
    /// </summary>
    public class BlogReview:Entity, IHasCreationTime
    {
        [Required, MaxLength(5000)]        
        public string CommentText { get; set; }
        
        public int BlogId { get; set; }

        /// </summary>
        public int CustomerId { get; set; }

        public DateTime CreationTime { get; set; }

        /// <summary>
        /// 支持
        /// </summary>
        public int Digg { get; set; }

        /// <summary>
        /// 反对
        /// </summary>
        public int Bury { get; set; }
    }
}
