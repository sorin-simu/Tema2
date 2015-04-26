using System.Web.Mvc;

namespace Ministore.UI.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult LoginFailed()
        {
            return View("Index", model: "Incorect username or password.");
        }

        public ActionResult AccessDenied()
        {
            return View("Index",model:"Sorry, you are not authorized to view this page.");
        }
    }
}
