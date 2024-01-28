using MovieInfo.Application.Contracts.Models;

namespace MovieInfo.Application.Services
{
    public interface IMovieService
    {
        public Task<Movie> GetMovieAsync(string movieName);
    }
}
