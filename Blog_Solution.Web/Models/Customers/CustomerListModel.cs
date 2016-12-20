using Blog_Solution.Web.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Blog_Solution.Web.Models.Customers
{
    public class CustomerListModel
    {
        public CustomerListModel()
        {
            this.AvailableRoles = new List<SelectListItem>();
        }
        [ResourceDisplayName("Common.Keywords")]
        public string Keywords { get; set; }
        
        [ResourceDisplayName("Customers.CustomerRoles")]
        [UIHint("MultiSelect")]
        public List<int> SearchCustomerRoleIds { get; set; }

        [ResourceDisplayName("Customers.IsAdmin")]
        public bool? IsAdmin { get; set; }



        [ResourceDisplayName("Customers.CreatedFrom")]
        [UIHint("DateTimeNullable")]
        public DateTime? CreatedFrom { get; set; }
        [ResourceDisplayName("Customers.CreatedTo")]
        [UIHint("DateTimeNullable")]
        public DateTime? CreatedTo { get; set; }

        public IList<SelectListItem> AvailableRoles { get; set; }
    }
}