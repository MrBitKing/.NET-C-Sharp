using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Lab4.Models;

namespace Lab4.Controllers
{
    public class HomeController : Controller
    {
        private MovieContext _movieContext;

        public HomeController(MovieContext context){
            _movieContext = context;
        }

        public IActionResult Index()
        {
            return View(_movieContext.Movies.ToList());
             
        }

        public IActionResult AddMovie()
        {
            return View();
        }

        public IActionResult CreateMovie(Movie movie)
        {
            _movieContext.Movies.Add(movie);
            _movieContext.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult EditMovie(int id)
        {

            var movieToUpdate = (from m in _movieContext.Movies where m.ID == id select m).FirstOrDefault();
            return View(movieToUpdate);
        }

        public IActionResult ModifyMovie(Movie movie)
        {
            var id = Convert.ToInt32(Request.Form["ID"]);

            var movieToUpdate = (from m in _movieContext.Movies where m.ID == id select m).FirstOrDefault();

            movieToUpdate.Title = movie.Title;
            movieToUpdate.SubTitle = movie.SubTitle;
            movieToUpdate.Description = movie.Description;
            movieToUpdate.Year = movie.Year;
            movieToUpdate.Rating = movie.Rating;

            _movieContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult DeleteMovie(int id)
        {
            var movieToDelete = (from m in _movieContext.Movies where m.ID == id select m).FirstOrDefault();

            _movieContext.Movies.Remove(movieToDelete);
            _movieContext.SaveChanges();
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
