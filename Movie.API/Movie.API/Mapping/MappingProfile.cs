using AutoMapper;
using Movie.API.Models;

namespace Movie.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Models.Movie, MovieToPost>();
        }
    }
}