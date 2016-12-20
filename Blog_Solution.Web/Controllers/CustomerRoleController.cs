using Abp.AutoMapper;
using Blog_Solution.Customers;
using Blog_Solution.Domain.Customers;
using Blog_Solution.Web.Framework.Kendoui;
using Blog_Solution.Web.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_Solution.Web.Controllers
{
    public class CustomerRoleController : Blog_SolutionControllerBase
    {
        #region Fields && Ctor
        private readonly ICustomerRoleService _roleService;
        /// <summary>
        /// 构造，因为有注入所以不用担心
        /// </summary>
        /// <param name="roleService"></param>
        public CustomerRoleController(ICustomerRoleService roleService)
        {
            this._roleService = roleService;
        }
        #endregion

        #region Utilities
        //组建用户角色实体
        [NonAction]
        private void PrepareCustomerRoleModel(CustomerRoleModel model)
        {
            var parentRoles = _roleService.GetAllRoles(showHidden: true,
                                     parentIds: new List<int> { 0 }
                                     );

            if (model == null)
                model = new CustomerRoleModel();

            model.AvailableParentRole.Add(new SelectListItem
            {
                Selected = model.ParentId == 0,
                Text = "顶级角色",
                Value = "0",
            });

            foreach (var item in parentRoles.Items)
            {
                model.AvailableParentRole.Add(new SelectListItem {
                    Selected = model.ParentId == item.Id,
                    Text = item.RoleName,
                    Value = item.Id.ToString(),
                });
            }
        }
        #endregion
        /// <summary>
        /// 列表页面
        /// </summary>
        /// <returns></returns>
        #region Method
        public ActionResult List()
        {
            var model = new CustomerRoleListModel();
            return View(model);
        }

        /// <summary>
        /// 列表请求的数据（我用的是Kendoui大家可以试试很好用）
        /// </summary>
        /// <param name="command"></param>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult List(DataSourceRequest command ,CustomerRoleListModel model)
        {
            var datas = _roleService.GetAllRoles(keywords: model.Keywords,
                                                showHidden: true,
                                                pageIndex: command.Page - 1,
                                                pageSize: command.PageSize);
            var data = new DataSourceResult {
                Data = datas.Items,
                Total = datas.TotalCount
            };
            return AbpJson(data);

        }

        /// <summary>
        /// 新增页面
        /// </summary>
        /// <returns></returns>
        public ActionResult Create()
        {
            var model = new CustomerRoleModel();
            PrepareCustomerRoleModel(model);
            return View(model);
        }

        /// <summary>
        /// 新增逻辑
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Create(CustomerRoleModel model)
        {
            if (ModelState.IsValid)
            {
                //这里就是页面实体映射的关键，我可以把页面的实体转换为数据库的实体在进行操作
                //但是还需要一小步在web项目中的App_Start文件夹中有个Blog_SolutionWebModule类，我们要注意下
                //去看看就知道了
                var entity = model.MapTo<CustomerRole>();
                _roleService.InsertCustomerRole(entity);
                return RedirectToAction("List");
            }

            PrepareCustomerRoleModel(model);
            return View(model);
        }
        #endregion

    }
}