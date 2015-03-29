using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using DI_UoW.Model.Entities;
using DI_UoW.Service.UserService;
using DI_UoW.ViewModel;

namespace DI_UoW.Controllers
{
    [Authorize]
    public class AccountController : BaseController
    {
        private readonly IUserService m_userService;

        public AccountController(IUserService userService)
        {
            m_userService = userService;
        }

        //
        // GET: /Account/
        [AllowAnonymous]
        public async Task<ActionResult> Index()
        {
            var users = await m_userService.GetAllAsync();
            var usersViewModel = Mapper.Map<IEnumerable<ApplicationUser>, IEnumerable<AccountViewModel>>(users);
            return View(usersViewModel);
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register(AccountViewModel model)
        {
            var user = Mapper.Map<AccountViewModel, ApplicationUser>(model);
            await m_userService.InsertAsync(user, model.Password);

            return View("Login");
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }

        //
        // POST: /Account/Login
        /// <summary>
        /// Action used for authentication and authorization of user
        /// </summary>
        /// <param name="model">Viewmodel of Login User</param>
        /// <param name="returnUrl">Return Url for redirect</param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (returnUrl != null) @ViewBag.ReturnUrl = returnUrl;
            if (!ModelState.IsValid) return View(model);

            var user = await m_userService.FindAsync(model.UserName, model.Password);
            if (user == null)
            {
                Elmah.ErrorSignal.FromCurrentContext()
                    .Raise(new ApplicationException("Invalid Credentials"));

                ModelState.AddModelError("authstatusmessage", "Invalid Credentials");

                return View(model);
            }
            var loginViewModel = Mapper.Map<ApplicationUser, AccountViewModel>(user);
            if (!loginViewModel.Activated)
            {
                Elmah.ErrorSignal.FromCurrentContext()
                    .Raise(new ApplicationException("Account not yet activated"));

                ModelState.AddModelError("authstatusmessage", "Account not yet activated");
                return View(model);
            }

            return RedirectToActionPermanent("Index", "Home");
        }

        /// <summary>
        /// Sign In functionality
        /// 
        /// Below example show how to retieve user indentity claims
        /// 
        /// <example>
        /// var roles = ((ClaimsIdentity)User.Identity).Claims
        /// .Where(c => c.Type == ClaimTypes.Role)
        /// .Select(c => c.Value).FirstOrDefault();
        /// </example>
        /// </summary>
        /// <param name="id">Id of user</param>
        /// <param name="user">User object</param>
        /// <param name="userTypeId">User type Id</param>
        /// <param name="isPersistent">Indicating the persistant of cookie</param>
        /// <returns></returns>
        private async Task SignInAsync(ApplicationUser user, bool isPersistent)
        {
            await Helpers.Helper.SignInAsync(this, user, isPersistent, m_userService);

            user.LastLoginTime = DateTime.Now;
            await m_userService.Update(user);
        }

        //
        // GET: /Account/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Account/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Account/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Account/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Account/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Account/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Account/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
