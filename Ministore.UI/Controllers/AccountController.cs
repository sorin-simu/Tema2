using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Ministore.BusinessLogic.Services.Interfaces;
using Ministore.UI.Attributes;
using Ministore.UI.Models;

namespace Ministore.UI.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        public ActionResult Index()
        {
            var x = System.Web.HttpContext.Current.User.Identity;
            var model = new LoginViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel account)
        {
            var x = System.Web.HttpContext.Current.User.Identity;
            var user = _userService.GetUser(account.UserName, account.Password);
            if (user==null)
            {
                return RedirectToAction("LoginFailed", "Error");
            }

            AuthenticateUser(user.Name);
            return RedirectToAction("UserDashboard");
        }

        private void AuthenticateUser(string userName)
        {
            HttpCookie authCookie = GenerateAuthenticationCookie(userName);
            Response.Cookies.Add(authCookie);
        }

        private HttpCookie GenerateAuthenticationCookie(string userName)
        {
            var authTicket = new FormsAuthenticationTicket(userName, false, int.Parse(ConfigurationManager.AppSettings["AuthCookieTimeout"]));
            var encriptedTicket = FormsAuthentication.Encrypt(authTicket);
            var authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encriptedTicket);
            return authCookie;
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Account");
        }

        [AuthAttribute]
        public ActionResult UserDashboard()
        {
            return View();
        }

    }
}
