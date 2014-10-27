using Microsoft.AspNet.Mvc;

namespace MyMovies.Controllers
{
    public class HomeController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }
    }
}
