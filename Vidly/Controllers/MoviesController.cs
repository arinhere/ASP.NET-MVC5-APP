using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        private ApplicationDbContext db;

        public MoviesController()
        {
            db=new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: Movies
        public ActionResult Index()
        {
            if(User.IsInRole(UserRole.CanManageMovies))
                return View("Index");

            return View("List");
        }

        [Authorize(Roles = UserRole.CanManageMovies)]
        public ActionResult Create(int? id)
        {
            if (id == null) //This is create Movie
            {
                ViewBag.MovieGenreId = new SelectList(db.MovieGenres, "Id", "Genre");
                return View();
            }
            else//This is for edit movie
            {
                ViewBag.Id = id;
                Movies Movies = db.Movies.Find(id);

                if (Movies == null)
                {
                    return HttpNotFound();
                }
                else
                {
                    ViewBag.MovieGenreId = new SelectList(db.MovieGenres, "Id", "Genre", Movies.MovieGenreId);
                    return View(Movies);
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = UserRole.CanManageMovies)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movies movies)
        {
            if (movies.Id == 0)
            {
                if (ModelState.IsValid)
                {
                    movies.Available = movies.InStock;
                    movies.AddedDate = DateTime.Now.Date;
                    db.Movies.Add(movies);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            else
            {
                if (ModelState.IsValid)
                {
                    var moviesInDb = db.Movies.Single(c => c.Id == movies.Id);

                    moviesInDb.MovieName = movies.MovieName;
                    moviesInDb.MovieGenreId = movies.MovieGenreId;
                    moviesInDb.InStock = movies.InStock;
                    moviesInDb.ReleaseDate = movies.ReleaseDate;

                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }

            ViewBag.MovieGenreId=new SelectList(db.MovieGenres, "Id", "Genre", movies.MovieGenreId);
            return View(movies);
        }

        [Authorize(Roles = UserRole.CanManageMovies)]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult();
            }
            else
            {
                Movies movies = db.Movies.Find(id);

                if (movies == null)
                {
                    return new HttpNotFoundResult();
                }
                else
                {
                    ViewBag.MovieGenreId=new SelectList(db.MovieGenres,"Id", "Genre", movies.MovieGenreId);
                    return View(movies);
                }
            }
        }

        [HttpPost]
        [Authorize(Roles = UserRole.CanManageMovies)]
        public ActionResult Edit(Movies movies)
        {
            //Check create HTTPPOST Action...it has been moved there.
            return View();
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult();
            }

            Movies movies = db.Movies.Find(id);
            return View(movies);
        }

        [HttpPost, ActionName("Delete")]
        [Authorize(Roles = UserRole.CanManageMovies)]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            Movies movies = db.Movies.Find(id);
            db.Movies.Remove(movies);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpNotFoundResult();
            }

            Movies movies = db.Movies.Find(id);
            return View(movies);
        }


    }
}