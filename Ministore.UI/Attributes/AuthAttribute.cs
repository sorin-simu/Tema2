using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Ministore.BusinessLogic.Services.Interfaces;

namespace Ministore.UI.Attributes
{
    public class AuthAttribute : AuthorizeAttribute
    {
        public override void OnAuthorization(AuthorizationContext authorizationContext)
        {
            var userName = HttpContext.Current.User.Identity.Name;
            var isAuthorized = AuthUser(userName);
            if (!isAuthorized)
            {
                HandleUnauthorizedRequest(authorizationContext);
            }
            base.OnAuthorization(authorizationContext);
        }

        private bool AuthUser(string userName)
        {
            var userService = (IUserService)DependencyResolver.Current.GetService(typeof(IUserService));
            var currentUser = userService.GetUserByName(userName);
            return currentUser != null;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext authorizationContext)
        {
            authorizationContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Error", action = "AccessDenied" }));
        }
    }
}