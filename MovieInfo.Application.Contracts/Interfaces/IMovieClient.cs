using MovieInfo.Application.Contracts.Models;

namespace MovieInfo.Application.Contracts.Services
{
    public interface IMovieClient
    {
        public Task<Movie> GetMovieAsync(string movieName);
        public string GetName();
    }
}
