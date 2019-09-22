using System.Collections.Generic;

namespace Movie.API.Models
{
    public class Studio
    {
        public int StudioId { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public IEnumerable<Movie> Movies { get; set; }
    }
}