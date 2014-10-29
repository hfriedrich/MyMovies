using Microsoft.AspNet.Mvc;
using MovieImportService;
using System.Collections.Generic;
using System.Linq;

namespace MyMovies.Controllers
{
    public class MyFavouritesController
    {
        private static HashSet<string> _favouriteIds;
        private readonly IMovieImporter _movieImporter;

        [Activate]
        public ViewDataDictionary ViewData { get; set; }

        public MyFavouritesController(IMovieImporter movieImporter)
        {
            _movieImporter = movieImporter;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var allMovies = _movieImporter.ImportMovies();
            var model = allMovies.Where(m => GetFavouriteIds().Contains(m.Id)).ToList();
            ViewData.Model = model;
            return new ViewResult() { ViewData = ViewData };
        }

        public void Put(string id)
        {
            GetFavouriteIds().Add(id);
        }

        private HashSet<string> GetFavouriteIds()
        {
            if (_favouriteIds == null)
            {
                _favouriteIds = new HashSet<string>();
            }
            return _favouriteIds;
        }
    }
}