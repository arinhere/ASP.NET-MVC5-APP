using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using AutoMapper;
using Vidly.Dto;
using Vidly.Models;

namespace Vidly.Controllers.api
{
    public class MoviesController : ApiController
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

        public IHttpActionResult GetMovies(string term=null)
        {
            var movies = db.Movies.Include(c=>c.MovieGenre);
            
            if(!string.IsNullOrWhiteSpace(term))
                movies=movies.Where(c=> c.MovieName.Contains(term));

            var moviesDTO=movies.ToList().Select(Mapper.Map<Movies,MoviesDto>);
            if (movies == null)
            {
                throw new Exception(HttpStatusCode.NotFound.ToString());
            }
            else
            {
                return Ok(moviesDTO);
            }
        }

        [HttpGet]
        public MoviesDto GetMovie(int id)
        {
            var movie = db.Movies.SingleOrDefault(c=>c.Id==id);
            if (movie == null)
            {
                throw new Exception(HttpStatusCode.NotFound.ToString());
            }
            else
            {
                return Mapper.Map<Movies,MoviesDto>(movie);
            }
        }

        [HttpPost]
        [Authorize(Roles = UserRole.CanManageMovies)]
        public IHttpActionResult CreateMovie(MoviesDto moviesDto)
        {
            if (moviesDto == null)
            {
                return BadRequest();
            }
            else
            {
                var movie = Mapper.Map<MoviesDto, Movies>(moviesDto);
                movie.Available = moviesDto.InStock;
                movie.AddedDate = DateTime.Today.Date;
                db.Movies.Add(movie);
                db.SaveChanges();
            }

            return Created(new Uri(Request.RequestUri + "/" + moviesDto.Id), moviesDto);
        }

        [HttpPut]
        [Authorize(Roles = UserRole.CanManageMovies)]
        public void UpdateMovie(MoviesDto moviesDto)
        {
            var movDtoDemo = Mapper.Map<MoviesDto, Movies>(moviesDto);
            var movieInDb = db.Movies.Find(moviesDto.Id);

            if (movieInDb == null)
            {
                throw new Exception(HttpStatusCode.NotFound.ToString());
            }
            else
            {
                if (ModelState.IsValid)
                {
                    movieInDb.MovieName= movDtoDemo.MovieName;
                    movieInDb.MovieGenreId = movDtoDemo.MovieGenreId;
                    movieInDb.ReleaseDate = movDtoDemo.ReleaseDate;
                    movieInDb.InStock = movDtoDemo.InStock;

                    db.SaveChanges();
                }
            }
        }

        [HttpDelete]
        [Authorize(Roles = UserRole.CanManageMovies)]
        public void DeleteMovie(int id)
        {
            var movie = db.Movies.Find(id);
            if (movie == null)
            {
                throw new Exception(HttpStatusCode.NotFound.ToString());
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Movies.Remove(movie);
                    db.SaveChanges();
                }
            }
        }


    }
}
