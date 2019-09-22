namespace Movie.API.Models
{
    public class Rating
    {
        public int RatingId { get; set; }
        public int Stars { get; set; }
        public Movie Movie { get; set; }
    }
}