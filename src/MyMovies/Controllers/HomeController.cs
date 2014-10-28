using Microsoft.AspNet.Mvc;
using MovieImportService;

namespace MyMovies.Controllers
{
    public class HomeController : Controller
    {
        private readonly IMovieImporter _movieImporter;

        public HomeController(IMovieImporter movieImporter)
        {
            _movieImporter = movieImporter;
        }

        public IActionResult Index()
        {
            var model = _movieImporter.ImportMovies();
            return View(model);
        }
    }
}
