using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.SqlServer.Server;

namespace Vidly.Models
{
    public class MovieGenre
    {
        public int Id { get; set; }
        public string Genre { get; set; }
    }
}