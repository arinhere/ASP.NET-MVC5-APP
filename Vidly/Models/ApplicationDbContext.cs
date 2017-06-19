using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Vidly.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Customers> Customers { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<MovieGenre> MovieGenres { get; set; }

        
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<Vidly.Models.MovieRental> MovieRentals { get; set; }
    }
}