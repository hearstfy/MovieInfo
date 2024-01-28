using Microsoft.Extensions.Caching.Memory;
using MovieInfo.Application.Contracts.Interfaces;
using MovieInfo.Application.Contracts.Models;
using MovieInfo.Application.Contracts.Services;

namespace MovieInfo.Application.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieClient _omdbClient;
        private readonly IMovieClient _vimeoClient;
        private readonly IMemoryCache _memoryCache;


        public MovieService(IMovieClientFactory movieClientFactory, IMemoryCache memoryCache)
        {
            _omdbClient = movieClientFactory.GetMovieClient("OmdbApiClient");
            _vimeoClient = movieClientFactory.GetMovieClient("VimeoApiClient");
            _memoryCache = memoryCache;
        }

        public async Task<Movie> GetMovieAsync(string movieName)
        {
            var movie = GetMovieFromCache(movieName);
            if (movie == null)
            {
                movie = await GetMovieFromApisAsync(movieName);
                _memoryCache.Set(movieName, movie, TimeSpan.FromMinutes(5));
            }

            return movie;
        }

        private async Task<Movie> GetMovieFromApisAsync(string movieName)
        {
            var movieInformation = await _omdbClient.GetMovieAsync(movieName);
            var movieVideos = await _vimeoClient.GetMovieAsync(movieInformation.MovieInformation.Title);
            
            movieInformation.MovieVideos = movieVideos.MovieVideos;
            return movieInformation;
        }

        private Movie GetMovieFromCache(string movieName)
        {
            var movie = _memoryCache.TryGetValue(movieName, out Movie movieInformation) ? movieInformation : null;

            return movie;
        }

    }
}
