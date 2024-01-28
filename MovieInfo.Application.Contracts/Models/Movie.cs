namespace MovieInfo.Application.Contracts.Models
{
    public class Movie
    {
        public MovieInformation MovieInformation { get; set; }
        public List<MovieVideo> MovieVideos { get; set; }
    }

    public class MovieInformation
    {
        public string Title { get; set; }
        public string Year { get; set; }
        public string Released { get; set; }
        public string Genre { get; set; }
        public string Director { get; set; }
        public string Writer { get; set; }
        public string Actors { get; set; }
        public string Plot { get; set; }
    }

    public class MovieVideo
    {
        public string Url { get; set; }
    }
}
