using Microsoft.Extensions.DependencyInjection;
using MovieInfo.Application.Services;

namespace MovieInfo.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddTransient<IMovieService, MovieService>();
            
            return services;
        }
    }
}
