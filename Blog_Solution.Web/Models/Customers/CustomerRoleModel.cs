using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Blog_Solution.Domain.Customers;
using Blog_Solution.Web.Framework;
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

        [ResourceDisplayName("CustomerRole.Enabled")]
        [Required]
        public bool Enabled { get; set; }

        [ResourceDisplayName("CustomerRole.RoleName")]
        [Required, MaxLength(20)]
        public string RoleName { get; set; }

        [ResourceDisplayName("Common.DisplayOrder")]
        [UIHint("DisplayOrder")]
        public int DisplayOrder { get; set; }

        [ResourceDisplayName("CustomerRole.IsAdmin")]
        public bool IsAdmin { get; set; }


        [ResourceDisplayName("CustomerRole.ParentId")]
        [Required]
        public int ParentId { get; set; }

        [ResourceDisplayName("CustomerRole.IsDefault")]
        public bool IsDefault { get; set; }


        public IList<SelectListItem> AvailableParentRole { get; set; }
    }
}