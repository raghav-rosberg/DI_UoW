using System.Linq;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using DI_UoW.Model.Entities;
using DI_UoW.Service.UserService;
using System;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace DI_UoW.Helpers
{
    public class Helper
    {
        public static async Task SignInAsync(Controller controller, ApplicationUser user, bool isPersistent, IUserService userService)
        {
            var authnManager = controller.HttpContext.GetOwinContext().Authentication;
            if (authnManager == null) throw new ArgumentNullException("controller");
            authnManager.SignOut(DefaultAuthenticationTypes.ExternalCookie);
            SignOut(controller);
            var identity = await userService.SignInAsync(user);
            var roleId = user.Roles.FirstOrDefault(x => x.UserId.Equals(user.Id));
            identity.AddClaim(new Claim(ClaimTypes.Role, roleId == null ? "0" : roleId.ToString()));
            identity.AddClaim(new Claim(ClaimTypes.Sid, user.Id));
            identity.AddClaim(new Claim(ClaimTypes.Actor, user.DisplayName));
            authnManager.SignIn(new AuthenticationProperties() { IsPersistent = isPersistent }, identity);
        }

        public static void SignOut(Controller controller)
        {
            controller.HttpContext.GetOwinContext().Authentication.SignOut();
        }
    }
}