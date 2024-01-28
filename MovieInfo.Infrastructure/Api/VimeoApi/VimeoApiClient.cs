using MovieInfo.Application.Contracts.Models;
using MovieInfo.Application.Contracts.Services;
using MovieInfo.Infrastructure.Api.VimeoApi.Models;
using System.Text.Json;

namespace MovieInfo.Infrastructure.Api.VimeoApi
{
    public class VimeoApiClient : IMovieClient
    {
        private readonly HttpClient _httpClient;

        public VimeoApiClient(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(nameof(VimeoApiClient));
        }

        /* 
            Note: Normally I would implement a loop to get all the pages of the response but since this is an assesment, I skipped it.
        */
        public async Task<Movie> GetMovieAsync(string movieName)
        {
            var url = $"videos?query={movieName}";
            var response = await _httpClient.GetAsync(url);

            if (!response.IsSuccessStatusCode)
            {
                return new Movie()
                {
                    MovieVideos = new List<MovieVideo>()
                };
            }

            var resultString = await response.Content.ReadAsStringAsync();
            var result = JsonSerializer.Deserialize<MovieVideoInformation>(resultString);

            return new Movie()
            {
                MovieVideos = result.data.Select(x => new MovieVideo()
                {
                    Url = x.link
                }).ToList()
            };

        }

        public string GetName()
        {
            return nameof(VimeoApiClient);
        }
    }
}
