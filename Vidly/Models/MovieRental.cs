using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class MovieRental
    {
        public int Id { get; set; }

        public Movies Movies { get; set; }
        
        public Customers Customers { get; set; }

        public DateTime RentalDate { get; set; }

        public DateTime? ReturnDate { get; set; }
    }
}