using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JoelHilton_Elijah_McKay.Models
{
    public class MovieDBContext : DbContext
    {
        //inherit base options from the DbContext class
        public MovieDBContext(DbContextOptions<MovieDBContext> options) : base(options)
        {
            //ensures the database gets created.
            Database.EnsureCreated();
        }

        //creating the table in the database storing MovieResponse model objects
        public DbSet<MovieResponse> Movies { get; set; }
    }
}
