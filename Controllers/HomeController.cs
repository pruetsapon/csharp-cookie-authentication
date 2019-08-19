using System.Security.Claims;
using System.Web.Mvc;

namespace Identity.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}