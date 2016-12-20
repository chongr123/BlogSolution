using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Blog_Solution.Domain.Customers
{
    /// <summary>
    /// 用户实体
    /// </summary>
    public class Customer:Entity ,IHasCreationTime,IHasModificationTime
    {
        /// <summary>
        /// 登录名
        /// </summary>
        [Required, MaxLength(50), MinLength(5)]
        public string LoginName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        [Required, MaxLength(60), MinLength(10)]
        public string Password { get; set; }

        /// <summary>
        /// 用户角色
        /// </summary>
        [Required]
        public int CustomerRoleId { get; set; }        

        /// <summary>
        /// 手机号
        /// </summary>
        [Required, MaxLength(12), MinLength(11)]
        public string Mobile { get; set; }
        /// <summary>
        /// 邮箱
        /// </summary>
        [Required, MaxLength(200), MinLength(8)]
        public string Email { get; set; }
        
        /// <summary>
        /// 秘钥
        /// </summary>
        [Required, MaxLength(20)]
        public string PasswordSalt { get; set; }

        /// <summary>
        /// 加密方式
        /// </summary>
        [Required]
        public int PasswordFormatId { get; set; }
        /// <summary>
        /// 是否删除
        /// </summary>
        [Required]
        public bool Deleted { get; set; }


        /// <summary>
        /// 最后登录IP
        /// </summary>
        [MaxLength(16)]
        public string LastIpAddress { get; set; }
        
        /// <summary>
        /// 最后修改时间（不需要处理）
        /// </summary>
        public DateTime? LastModificationTime { get; set; }

        /// <summary>
        /// 创建时间（不需要处理）
        /// </summary>
        public DateTime CreationTime { get; set; }


        /// <summary>
        /// 加密方式(不映射)
        /// </summary>
        [NotMapped]
        public virtual PasswordFormat PasswordFormat
        {
            get { return (PasswordFormat)PasswordFormatId; }
            set { this.PasswordFormatId = (int)value; }
        }
    }
}
