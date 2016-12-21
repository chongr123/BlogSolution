using Abp.AutoMapper;
using Abp.Localization.Sources;
using Blog_Solution.Customers;
using Blog_Solution.Domain.Customers;
using Blog_Solution.Web.Framework;
using Blog_Solution.Web.Framework.Controllers;
using Blog_Solution.Web.Framework.Mvc;
using Blog_Solution.Web.Models.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blog_Solution.Web.Controllers
{
    public class CustomerController : Blog_SolutionControllerBase
    {
        #region Fields && Ctor
        private readonly ICustomerService _customerService;
        private readonly ICustomerRoleService _roleService;
        public CustomerController(ICustomerService customerService, ICustomerRoleService roleService)
        {
            this._customerService = customerService;
            this._roleService = roleService;
        }
        #endregion

        #region Utilities
        [NonAction]
        protected virtual void PrepareCustomerListModel(CustomerListModel model)
        {
            if (model == null)
                throw new ArgumentNullException("customerRole");

            var roles = _roleService.GetAllRoles(showHidden: true);

            foreach (var customerRole in roles.Items)
            {
                model.AvailableRoles.Add(new SelectListItem
                {
                    Text = customerRole.RoleName,
                    Value = customerRole.Id.ToString(),
                });
            }
        }


        [NonAction]
        protected virtual void PrepareCustomerModel(CustomerModel model, bool isAdmin = true)
        {
            model.AvailableCustomerRoles.Add(new SelectListItem
            {
                Text = "请选择角色",
                Value = "0"
            });
            var roles = _roleService.GetAllRoles(isAdmin: isAdmin);
            foreach (var role in roles.Items)
            {
                model.AvailableCustomerRoles.Add(new SelectListItem
                {
                    Text = role.RoleName,
                    Value = role.Id.ToString(),
                });
            }

            model.AvailablePasswordFormats = PasswordFormat.Clear.ToSelectList(LocalizationSource, false).ToList();
        }
        #endregion

        #region Method


        public ActionResult List()
        {
            return View();
        }
             

        public ActionResult Create()
        {
            var model = new CustomerModel();
            PrepareCustomerModel(model, true);
            return View(model);
        }


        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Create(CustomerModel model, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                var customer = model.MapTo<Customer>();
                _customerService.InsertCustomer(customer);               

                if (continueEditing)
                {
                    return RedirectToAction("Edit", new { id = customer.Id });
                }
                return RedirectToAction("List");
            }

            PrepareCustomerModel(model);
            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
                return RedirectToAction("List");
            var model = customer.MapTo<CustomerModel>();

            var currentRole = _roleService.GetCustomerRoleById(model.CustomerRoleId);

            PrepareCustomerModel(model, currentRole.IsAdmin);
            return View(model);
        }


        [HttpPost, ParameterBasedOnFormName("save-continue", "continueEditing")]
        public ActionResult Edit(CustomerModel model, bool continueEditing)
        {
            if (ModelState.IsValid)
            {
                var customer = model.MapTo<Customer>();
                _customerService.UpdateCustomer(customer);

                if (continueEditing)
                {
                    return RedirectToAction("Edit", new { id = customer.Id });
                }
                return RedirectToAction("List");
            }

            PrepareCustomerModel(model);
            return View(model);
        }

        public ActionResult Delete(int id)
        {
            var customer = _customerService.GetCustomerById(id);
            if (customer == null)
                throw new ArgumentException("用户不存在");
            customer.Deleted = true;
            _customerService.UpdateCustomer(customer);

            return new NullJsonResult();
        }
        #endregion
    }
}