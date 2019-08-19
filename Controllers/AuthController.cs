using Identity.Models;
using System.Security.Claims;
using System.Web;
using System.Web.Mvc;

namespace Identity.Controllers
{
    [AllowAnonymous]
    public class AuthController : Controller
    {
        [HttpGet]
        public ActionResult Login(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (model.Username == "pruetsapon" && model.Password == "123456789")
            {
                var identity = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, "pruetsapon"),
                    new Claim(ClaimTypes.Email, "pruetsapon@gmail.com")
                },"ApplicationCookie");

                var ctx = Request.GetOwinContext();
                var authManager = ctx.Authentication;

                authManager.SignIn(identity);

                return Redirect(GetRedirectUrl(model.ReturnUrl));
            }

            ModelState.AddModelError("", "Invalid email or password");
            return View();
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authManager = ctx.Authentication;

            authManager.SignOut("ApplicationCookie");
            return RedirectToAction("LogIn", "Auth");
        }

        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }
    }
}