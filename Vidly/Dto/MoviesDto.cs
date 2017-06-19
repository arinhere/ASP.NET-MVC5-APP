using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.Dto
{
    public class MoviesDto
    {
        public int Id { get; set; }

        public string MovieName { get; set; }

        public int MovieGenreId { get; set; }

        public MovieGenreDto MovieGenre { get; set; }

        public int InStock { get; set; }
    }
}