using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using Blog_Solution.Domain.Catalogs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Blog_Solution.Web.Models.Catalogs
{
    [AutoMap(typeof(Category))]
    public class CategoryModel:EntityDto
    {
        public CategoryModel()
        {
            this.AvailableCategories = new List<SelectListItem>();
        }

        [Required, MaxLength(50), MinLength(2)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }


        public bool Enabled { get; set; }

        [Required]
        public int ParentId { get; set; }

        public int DisplayOrder { get; set; }

        public IList<SelectListItem> AvailableCategories { get; set; }

    }
}