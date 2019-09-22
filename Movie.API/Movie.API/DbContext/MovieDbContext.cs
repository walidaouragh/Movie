using Microsoft.EntityFrameworkCore;
using Movie.API.Models;

namespace Movie.API.DbContext
{
    public class MovieDbContext : Microsoft.EntityFrameworkCore.DbContext
    {

        
        public DbSet<Models.Movie> Movies { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Studio> Studios { get; set; }
        
        public MovieDbContext() { }
        public MovieDbContext(DbContextOptions<MovieDbContext> options): base(options) { }
    }
}