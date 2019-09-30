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

        public async Task<Studio> CreateStudio(StudioToPost studioToPost)
        {
            var addStudio = new Studio
            {
                Name = studioToPost.Name,
                City = studioToPost.City,
                State = studioToPost.State
            };
              _context.Studios.Add(addStudio);
              await _context.SaveChangesAsync();
              
              return addStudio;
        }

        public async Task UpdateStudio(Studio studio)
        {
            _context.Studios.Update(studio);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteStudio(int id)
        {
            var studio = _context.Studios.First(m => m.StudioId == id);
            _context.Studios.Remove(studio);
            await _context.SaveChangesAsync();
        }
    }
}