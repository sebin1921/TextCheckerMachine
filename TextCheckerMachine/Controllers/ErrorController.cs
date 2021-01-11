using System.Web.Mvc;

namespace TextCheckerMachine.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Forbidden()
        {
            return View();
        }

        public ActionResult NotFound()
        {
            return View();
        }
    }
}