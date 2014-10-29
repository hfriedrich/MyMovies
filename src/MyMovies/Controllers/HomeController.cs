using Microsoft.AspNet.Mvc;
using MovieImportService;

namespace MyMovies.Controllers
{
    public class HomeController
    {
        private readonly IMovieImporter _movieImporter;

        [Activate]
        public ViewDataDictionary ViewData { get; set; }

        public HomeController(IMovieImporter movieImporter)
        {
            _movieImporter = movieImporter;
        }

        public IActionResult Index()
        {
            var model = _movieImporter.ImportMovies();
            ViewData.Model = model;
            return new ViewResult() { ViewData = ViewData };
        }
    }
}