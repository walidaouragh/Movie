using System.Collections.Generic;
using System.Threading.Tasks;
using Movie.API.Models;

namespace Movie.API.Repositories.StudioRepository
{
    public interface IStudioRepository
    {
        List<Studio> GetStudios();

        Task<Studio> GetStudio(int id);
        Task<Studio> CreateStudio(StudioToPost studio);
    }
}