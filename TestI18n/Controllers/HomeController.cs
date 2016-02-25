using System.Web.Mvc;
using TestI18n.Models;

namespace TestI18n.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var model = new HomeViewModel();

            return View(model);
        }

        [HttpPost]
        public ActionResult Index(HomeViewModel homeViewModel)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("About");
            }

            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}