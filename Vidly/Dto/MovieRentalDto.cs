using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Vidly.Dto
{
    public class MovieRentalDto
    {
        public List<int> MovieId { get; set; }
        public int CustomerId { get; set; }
    }
}