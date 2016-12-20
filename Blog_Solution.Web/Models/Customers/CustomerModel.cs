using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Blog_Solution.Domain.Customers;
using Blog_Solution.Web.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Blog_Solution.Web.Models.Customers
{
    [AutoMap(typeof(Customer))]
    public class CustomerModel:EntityDto
    {
        public CustomerModel()
        {
            this.AvailableCustomerRoles = new List<SelectListItem>();
            this.AvailablePasswordFormats = new List<SelectListItem>();
        }

        [ResourceDisplayName("Customer.LoginName")]
        [Required, MaxLength(50), MinLength(5)]
        public string LoginName { get; set; }

        [ResourceDisplayName("Customer.Password")]
        [Required, MaxLength(60), MinLength(10)]
        public string Password { get; set; }

        [ResourceDisplayName("Customer.CustomerRoleId")]
        public int CustomerRoleId { get; set; }

        [ResourceDisplayName("Customer.Mobile")]
        [Required, MaxLength(12), MinLength(11)]
        public string Mobile { get; set; }

        [ResourceDisplayName("Customer.Email")]
        [Required, MaxLength(200), MinLength(8)]
        public string Email { get; set; }
        
        public string PasswordSalt { get; set; }

        [ResourceDisplayName("Customer.PasswordFormatId")]
        public int PasswordFormatId { get; set; }

        [ResourceDisplayName("Customer.Deleted")]
        public bool Deleted { get; set; }

        
        public string LastIpAddress { get; set; }
        
        public DateTime? LastModificationTime { get; set; }
        
        public DateTime CreationTime { get; set; }


        public List<SelectListItem> AvailableCustomerRoles { get; set; }
        public List<SelectListItem> AvailablePasswordFormats { get; set; }

    }
}
