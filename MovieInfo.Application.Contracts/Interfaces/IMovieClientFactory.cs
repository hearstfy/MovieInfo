using MovieInfo.Application.Contracts.Services;

namespace MovieInfo.Application.Contracts.Interfaces
{
    public interface IMovieClientFactory
    {
        IMovieClient GetMovieClient(string movieClientType);
    }
}
