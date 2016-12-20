using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Blog_Solution.Domain.Customers;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Blog_Solution.Web.Models.Customers
{
    [AutoMap(typeof(CustomerRole))]
    public class CustomerRoleModel:EntityDto
    {
        public CustomerRoleModel() {
            this.AvailableParentRole = new List<SelectListItem>();
        }

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
        [UIHint("DisplayOrder")]
        public int DisplayOrder { get; set; }

        /// <summary>
        /// 是否后台用户
        /// </summary>
        public bool IsAdmin { get; set; }

        /// <summary>
        /// 父节点
        /// </summary>
        [Required]
        public int ParentId { get; set; }

        /// <summary>
        /// 是否默认注册用户
        /// </summary>
        public bool IsDefault { get; set; }


        public IList<SelectListItem> AvailableParentRole { get; set; }
    }
}