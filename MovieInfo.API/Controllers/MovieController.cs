using Microsoft.AspNetCore.Mvc;
using MovieInfo.Application.Services;

namespace MovieInfo.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet("{movieName}")]
        public async Task<IActionResult> GetMovie(string movieName)
        {
            var movie = await _movieService.GetMovieAsync(movieName);
            return Ok(movie);
        }
    }
}
