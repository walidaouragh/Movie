using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Movie.API.Models;

namespace Movie.API.Repositories
{
    public interface IMovieRepository
    {
        List<Models.Movie> GetMovies();

        Task<Models.Movie> GetMovie(int id);
        
        IQueryable GetMoviesByCategory(string category);

        Task<Models.Movie> CreateMovie(MovieToPost movie);
        
        Task<Models.Movie> UpdateMovie(MovieToPost movie, int id);
        
        Task DeleteMovie(int id);
    }
}