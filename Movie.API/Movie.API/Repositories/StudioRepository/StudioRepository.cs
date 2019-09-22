using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Movie.API.DbContext;
using Movie.API.Models;

namespace Movie.API.Repositories.StudioRepository
{
    public class StudioRepository : IStudioRepository
    {
        private readonly MovieDbContext _context;

        public StudioRepository(MovieDbContext context)
        {
            _context = context;
        }
        public List<Studio> GetStudios()
        {
            return _context.Studios
                .OrderBy(s => s.StudioId).ToList();
        }

        public async Task<Studio> GetStudio(int id)
        {
            return await _context.Studios
                .SingleOrDefaultAsync(s => s.StudioId == id);
        }
    }
}