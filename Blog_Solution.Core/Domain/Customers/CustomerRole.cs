using Abp.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Blog_Solution.Domain.Customers
{
    /// <summary>
    /// 用户角色
    /// </summary>
    public class CustomerRole :Entity
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        [Required]
        public bool Enabled { get; set; }

        /// <summary>
        /// 角色名称
        /// </summary>
        [Required, MaxLength(20)]
        public string RoleName { get; set; }

        /// <summary>
        /// 排序
        /// </summary>
        [Required]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 是否后台用户
        /// </summary>
        [Required]
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        [Required]
        public int ParentId { get; set; }

        /// <summary>
        /// 是否默认注册用户
        /// </summary>
        [Required]
        public bool IsDefault { get; set; }
    }
}
