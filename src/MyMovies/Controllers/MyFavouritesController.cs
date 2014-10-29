using Microsoft.AspNet.Mvc;

namespace MyMovies.Controllers
{
    public class MyFavouritesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        public void Put(string id)
        {
        }
    }
}
