using Abp.AutoMapper;
using Blog_Solution.Catalog;
using Blog_Solution.Domain.Catalogs;
using Blog_Solution.Web.Framework.Controllers;
using Blog_Solution.Web.Framework.Kendoui;
using Blog_Solution.Web.Framework.Mvc;
using Blog_Solution.Web.Helper;
using Blog_Solution.Web.Models.Catalogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_Solution.Web.Controllers
{
    public class CategoryController : Blog_SolutionControllerBase
    {

        #region Fields && Ctor


        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this._categoryService = categoryService;
        }

        #endregion
        
        #region Utilities
        [NonAction]
        protected virtual void PrepareCategoryListModel(CategoryListModel model)
        {
            if (model == null)
                throw new ArgumentNullException("category");

            var topCategories = _categoryService.GetCagegoriesByParentId(0);
            foreach (var item in topCategories)
            {
                model.AvailableCategories.Add(new SelectListItem
                {
                    Text = item.Name,
                    Value = item.Id.ToString(),
                    Selected = model.ParentIds.Any(x => x == item.Id)
                });
            }
        }


        [NonAction]
        protected virtual void PrepareCategoryModel(CategoryModel model)
        {
            if (model == null)
                throw new ArgumentNullException("model");

            model.AvailableCategories.Add(new SelectListItem
            {
                Text = "顶级类别",
                Value = "0",
                Selected = model.ParentId == 0
            });
            var allCategories = SelectListHelper.GetCategoryList(_categoryService, true);
            foreach (var c in allCategories)
            {
                c.Selected = model.ParentId.ToString() == c.Value;
                model.AvailableCategories.Add(c);
            }
            if (model.Id == 0)
                model.DisplayOrder = 999;
        }
        #endregion

        #region  Method

        public ActionResult List()
        {
            var model = new CategoryListModel();
            PrepareCategoryListModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult List(DataSourceRequest command, CategoryListModel model)
        {
            var list = _categoryService.GetAllCategories(keywords: model.Keywords,
                                                        parentIds: model.ParentIds,
                                                        showHidden: true,
                                                        pageIndex: command.Page - 1,
                                                        pageSize: command.PageSize);
            var data = new DataSourceResult
            {
                Data = list.Items,
                Total = list.TotalCount
            };
            return AbpJson(data);
        }

        public ActionResult Create()
        {
            var model = new CategoryModel();
            PrepareCategoryModel(model);
            return View(model);
        }


        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Create(CategoryModel model, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                var entity = model.MapTo<Category>();
                _categoryService.InsertCategory(entity);
                if (continueEditing)
                {
                    return RedirectToAction("Edit", new { id = entity.Id });
                }
                return RedirectToAction("List");
            }

            PrepareCategoryModel(model);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var category = _categoryService.GetCagegoryById(id);
            var model = category.MapTo<CategoryModel>();
            PrepareCategoryModel(model);
            return View(model);
        }

        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Edit(CategoryModel model, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                var entity = model.MapTo<Category>();
                _categoryService.UpdateCategory(entity);

                if (continueEditing)
                {
                    return RedirectToAction("Edit", new { id = entity.Id });
                }
                return RedirectToAction("List");
            }

            PrepareCategoryModel(model);
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var category = _categoryService.GetCagegoryById(id);
            if (category == null)
                throw new ArgumentException("类别不存在");
            _categoryService.DeleteCategory(category);
            return new NullJsonResult();
        }
        #endregion
    }
}