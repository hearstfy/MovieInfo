using MovieInfo.Application.Contracts.Models;
using MovieInfo.Application.Contracts.Services;
using System.Text.Json;
using ApplicationException = MovieInfo.Application.Contracts.Exceptions.ApplicationException;

namespace MovieInfo.Infrastructure.Api.OmdbApi
{
    public class OmdbApiClient : IMovieClient
    {
        private HttpClient _httpClient;
        private readonly string _apiKey;
        private readonly string _apiUri;
        public OmdbApiClient(string apiKey, string apiUri)
        {
            _apiKey = apiKey;
            _apiUri = apiUri;
            _httpClient = new HttpClient();
        }

        public async Task<Movie> GetMovieAsync(string movieName)
        {
            var url = $"{_apiUri}?apikey={_apiKey}&t={movieName}";
            var response = await _httpClient.GetAsync(new Uri(url));

            if (!response.IsSuccessStatusCode)
            {
                throw new ApplicationException($"Error occured during fetching {movieName}", (int)response.StatusCode);
            }

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<MovieInformation>(resultString);

            return new Movie
            {
                MovieInformation = new MovieInformation
                {
                    Title = result.Title,
                    Year = result.Year,
                    Released = result.Released,
                    Genre = result.Genre,
                    Director = result.Director,
                    Writer = result.Writer,
                    Actors = result.Actors,
                    Plot = result.Plot
                }
            };
        }

        public string GetName()
        {
            return nameof(OmdbApiClient);
        }
    }
}
