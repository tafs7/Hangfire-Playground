using System.Web.Mvc;
using Serilog;

namespace HangFire_Playground.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            Log.Debug("loading the Home/Index view!");
            ViewBag.Title = "Home Page";

            return View();
        }
    }
}
