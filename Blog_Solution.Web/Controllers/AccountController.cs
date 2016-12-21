using Abp.Auditing;
using Blog_Solution.Customers;
using Blog_Solution.Customers.Dto;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blog_Solution.Web.Models.Account;

namespace Blog_Solution.Web.Controllers
{
    public class AccountController : Blog_SolutionControllerBase
    {
        #region Fields && Ctor

        
        private readonly LoginManager _loginManage;
        private readonly CustomerManager _customerManager;
        private readonly IAuthenticationService _authenticationService;

        public AccountController(IAuthenticationService authenticationService,
                                LoginManager loginManager,
                                CustomerManager customerManager)
        {
            this._authenticationService = authenticationService;
            this._loginManage = loginManager;
            this._customerManager = customerManager;
        }

        #endregion

        #region Utilities
        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }
        #endregion

        #region Login / Logout
        public ActionResult Login(string returnUrl = "")
        {
            if (string.IsNullOrWhiteSpace(returnUrl))
            {
                returnUrl = Request.ApplicationPath;
            }

            ViewBag.returnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [DisableAuditing]
        public ActionResult Login(LoginModel model)
        {
            var loginResult = _authenticationService.ValidateCustomer(model.LoginName, model.Password);
            switch (loginResult.Result)
            {
                case LoginResults.Successful:
                    {
                        //生成ClaimsIdentity
                        var identity = _loginManage.CreateUserIdentity(loginResult.Customer);

                        //用户登录
                        AuthenticationManager.SignIn(new AuthenticationProperties { IsPersistent = model.RememberMe }, identity);
                        
                        if (String.IsNullOrEmpty(model.ReturnUrl) || !Url.IsLocalUrl(model.ReturnUrl))
                            return RedirectToAction("Index", "Home");

                        return Redirect(model.ReturnUrl);
                    }

                case LoginResults.Deleted:
                    ModelState.AddModelError("", L("Account.Login.WrongCredentials.Deleted"));
                    break;
                case LoginResults.NotActive:
                    ModelState.AddModelError("", L("Account.Login.WrongCredentials.NotActive"));
                    break;
                case LoginResults.NotRegistered:
                    ModelState.AddModelError("", L("Account.Login.WrongCredentials.NotRegistered"));
                    break;
                case LoginResults.WrongPassword:
                default:
                    ModelState.AddModelError("", L("Account.Login.WrongCredentials"));
                    break;
            }

            return View(model);
        }


        public ActionResult Logout()
        {
            AuthenticationManager.SignOut();
            return RedirectToAction("Login");
        }

        #endregion

    }
}