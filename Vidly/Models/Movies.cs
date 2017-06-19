using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Movies
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Movie name required")]
        [Display(Name = "Movie Name")]
        public string MovieName { get; set; }

        public virtual MovieGenre MovieGenre { get; set; }
        [Required(ErrorMessage = "Please select movie genre")]
        public int MovieGenreId { get; set; }

        [Display(Name = "Release Date")]
        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Please provide release date")]
        public DateTime ReleaseDate { get; set; }

        [DisplayFormat(DataFormatString = "{0:d MMM yyyy}")]
        public DateTime AddedDate { get; set; }

        [Required(ErrorMessage = "You must provide stock.")]
        [Range(1,20,ErrorMessage = "Stock must be between 1 to 20.")]
        [Display(Name = "Stock")]
        public int InStock { get; set; }

        public int Available { get; set; }
    }
}