using System.Web.Mvc;

namespace OWINSample.Controllers
{
    [Authorize]
    public class SecretController : Controller
    {
        public ContentResult Secret() {
            return Content("This is a secret...");
        }
        
        [AllowAnonymous]
        public ContentResult Overt()
        {
            return Content("This is NOT a secret...");
        }
    }
}