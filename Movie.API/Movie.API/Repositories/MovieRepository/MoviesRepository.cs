using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie.API.DbContext;
using Movie.API.Models;

namespace Movie.API.Repositories
{
    public class MovieRepository : IMovieRepository
    {
        private readonly MovieDbContext _context;

        public MovieRepository(MovieDbContext context)
        {
            _context = context;
        }
        public List<Models.Movie> GetMovies()
        {
            var result = _context.Movies;
                
            return result.ToList();
        }

        public async Task<Models.Movie> GetMovie(int id)
        {
            var result = await _context.Movies
                .Include(s => s.Studio)
                .ThenInclude(s=>s.Movies)
                .Include(r => r.Ratings)
                .FirstOrDefaultAsync(m => m.MovieId == id);
            
            if (result != null)
            {
                if (result.Studio != null)
                {
                    result.Studio.Movies = result.Studio.Movies.Select(s=>
                        new Models.Movie{
                            MovieId = s.MovieId,
                            Name = s.Name,
                            Category = s.Category,
                            Description = s.Description,
                            Price = s.Price
                        });
                }
                if (result.Ratings != null)
                {
                    foreach (Rating r in result.Ratings)
                    {
                        r.Movie = null;
                    }
                }
            }
            return result;
        }
        
        public IQueryable GetMoviesByCategory(string category)
        {
            var result = _context.Movies.Where(m => m.Category == category);
            return result;
        }

        public async Task<Models.Movie> CreateMovie(MovieToPost movieToPost)
        {
            var addMovie = new Models.Movie
            {
                Name = movieToPost.Name,
                Category = movieToPost.Category,
                Description = movieToPost.Description,
                Price = movieToPost.Price,
            };
            
                _context.Movies.Add(addMovie);

             await _context.SaveChangesAsync();

             return addMovie;
        }

        public async Task UpdateMovie(Models.Movie movie)
        {
            _context.Movies.Update(movie);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMovie(int id)
        {
            var movie = _context.Movies.First(m => m.MovieId == id);
            _context.Movies.Remove(movie);
            await _context.SaveChangesAsync();
        }
    }
}