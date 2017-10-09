using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using WP.Models;

namespace WP.Controllers
{
    public class AccountController : BaseController
    {
        // GET: Account     
        public ActionResult Login()
        {
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            AppUser user = await UserManager.FindAsync(model.UserName, model.Password);

            if (user == null)
            {
                ModelState.AddModelError("", "Username or password is incorrect.");
            }
            else
            {
                ClaimsIdentity ident = await UserManager.CreateIdentityAsync(user,
                    DefaultAuthenticationTypes.ApplicationCookie);

                AuthManager.SignOut();
                AuthManager.SignIn(new AuthenticationProperties { IsPersistent = false }, ident);
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
        public ActionResult Register()
        {            
            if (HttpContext.User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppUser user = new AppUser { UserName = model.UserName, Email = model.Email };
                IdentityResult result =
                    await UserManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                    return RedirectToAction("Login");
                else
                    AddErrorsFromResult(result);                
            }
            return View(model);
        }
        [Authorize]
        public ActionResult Logout()
        {
            AuthManager.SignOut();
            return RedirectToAction("Login");
        }
        [Authorize]
        public async Task<ActionResult> Profile()
        {
            var userId = HttpContext.User.Identity.GetUserId();
            var user = await UserManager.FindByIdAsync(userId);
            return View(user);
        }
        private void AddErrorsFromResult(IdentityResult result)
        {
            foreach (string error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }
        }

        public JsonResult GetUsersByUsernameOrEmail(string criteria)
        {
            var user = UserManager.Users.Where(u => u.UserName.ToLower().Contains(criteria.ToLower())).Select(u => new { userName = u.UserName });
            return Json(new { results = user }, JsonRequestBehavior.AllowGet);
        }
    }
}