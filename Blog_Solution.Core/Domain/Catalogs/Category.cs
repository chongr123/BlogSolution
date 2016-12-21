using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System.ComponentModel.DataAnnotations;
using System;

namespace Blog_Solution.Domain.Catalogs
{
    /// <summary>
    /// 博客类别
    /// </summary>
    public class Category:Entity, IAudited,ISoftDelete
    {

        [Required, MaxLength(50), MinLength(2)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }


        public bool Enabled { get; set; }

        [Required]
        public int ParentId { get; set; }

        public int DisplayOrder { get; set; }

        public DateTime CreationTime { get; set; }

        public long? CreatorUserId { get; set; }

        public DateTime? LastModificationTime { get; set; }

        public long? LastModifierUserId { get; set; }

        public bool IsDeleted { get; set; }
    }
}
