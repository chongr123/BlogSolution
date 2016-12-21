using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;

namespace Blog_Solution.Domain.Catalogs
{
    public class Blog : Entity, IAudited,ISoftDelete
    {
        [Required, MaxLength(50), MinLength(2)]
        public string BolgTitle { get; set; }
        [Required, MaxLength(10), MinLength(2)]
        public string Author { get; set; }

        public int CategoryId { get; set; }

        /// <summary>
        /// 是否审核通过
        /// </summary>
        public bool Audit { get; set; }

        /// <summary>
        /// 内容
        /// </summary>
        public string Content { get; set; }

        [MaxLength(100)]
        public string Description { get; set; }
        
        public int BrowsingTimes { get; set; }

        public  int ReviewsTimes { get; set; }

        /// <summary>
        /// 推荐次数
        /// </summary>
        public int Start { get; set; }

        public DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
