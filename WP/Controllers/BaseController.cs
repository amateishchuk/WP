using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System.Web;
using System.Web.Mvc;
using WP.Models;

namespace WP.Controllers
{
    public class BaseController : Controller
    {
        private AppUserManager _userManager;
        private IAuthenticationManager _authManager;
        private AppRoleManager _roleManager;
        protected AppUserManager UserManager
        {
            get
            {
                if (_userManager == null)
                    _userManager = HttpContext.GetOwinContext().GetUserManager<AppUserManager>();
                return _userManager;
            }
        }
        protected IAuthenticationManager AuthManager
        {
            get
            {
                if (_authManager == null)
                    _authManager = HttpContext.GetOwinContext().Authentication;
                return _authManager;
            }
        }
        protected AppRoleManager RoleManager
        {
            get
            {
                if (_roleManager == null)
                    _roleManager = HttpContext.GetOwinContext().GetUserManager<AppRoleManager>();
                return _roleManager;
            }
        }
    }
}