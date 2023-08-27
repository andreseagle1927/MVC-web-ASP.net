using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using MovieRankMVC.Models;

namespace MovieRankMVC.Controllers
{
    public class MoviesController : Controller
    {
        //Global variables

        private static List<Movie> moviesList = LoadMovies();

    

        // GET: MoviesController
        public ActionResult Index()
        {
            return View(moviesList);
        }

        // GET: MoviesController/Details/5
        public ActionResult Details(int id)
        {
            var movie = moviesList.FirstOrDefault(x => x.Id == id);
            return View(movie);
        }

        // GET: MoviesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MoviesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                int id = moviesList.Count() + 1;
                string Title = collection["Title"];
                string Synopsis = collection["Synopsis"];
                int Year = int.Parse(collection["Year"]);
                string Duration = collection["Duration"];
                float Rate = float.Parse(collection["Rate"]);
                string Poster = collection["Poster"];
                string Genres = collection["Genres"];

                moviesList.Add(new Movie() { Id =id, Title = Title, Synopsis = Synopsis, Year = Year, Duration = Duration, Rate = Rate, Poster = Poster, Genres = Genres });
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: MoviesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: MoviesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // Encontrar la película en la lista según el ID
                Movie movieToUpdate = moviesList.FirstOrDefault(m => m.Id == id);

                if (movieToUpdate != null)
                {
                    // Actualizar las propiedades de la película con los valores del formulario
                    movieToUpdate.Title = collection["Title"];
                    movieToUpdate.Synopsis = collection["Synopsis"];
                    movieToUpdate.Year = int.Parse(collection["Year"]);
                    movieToUpdate.Duration = collection["Duration"];
                    movieToUpdate.Rate = float.Parse(collection["Rate"]);
                    movieToUpdate.Poster = collection["Poster"];
                    movieToUpdate.Genres = collection["Genres"];

                    // Redirigir a la acción Index después de la actualización exitosa
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // La película no se encontró, redirige a una página de error o maneja la situación
                    return NotFound();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: MoviesController/Delete/5
        public ActionResult Delete(int id)
        {
            Movie movieToDelete = moviesList.FirstOrDefault(m => m.Id == id);

            return View(movieToDelete);
        }

        // POST: MoviesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            Movie movieToDelete = moviesList.FirstOrDefault(m => m.Id == id);

            if (movieToDelete != null)
            {
                // Eliminar la película de la lista
                moviesList.Remove(movieToDelete);

                return RedirectToAction(nameof(Index));
            }
            else
            {
                // La película no se encontró, redirige a una página de error o maneja la situación
                return NotFound();
            }
        }

        #region Private-Methods
        private static List<Movie> LoadMovies()
        {
            List<Movie> movies = new List<Movie>();

            movies.Add(new Movie() { Id = 1, Title = "lod", Synopsis = "sl", Year = 2, Duration = "443" , Rate = 3.4f, Poster = "dd" , Genres = "dd" });
            movies.Add(new Movie() { Id = 2, Title = "lod", Synopsis = "sl", Year = 2, Duration = "443", Rate = 3.4f, Poster = "dd", Genres = "dd" });
            movies.Add(new Movie() { Id = 3, Title = "lod", Synopsis = "sl", Year = 2, Duration = "443", Rate = 3.4f, Poster = "dd", Genres = "dd" });

            return movies;
        }
        #endregion Private-Methods
    }
}
