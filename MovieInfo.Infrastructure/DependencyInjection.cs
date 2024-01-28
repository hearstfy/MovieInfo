using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MovieInfo.Application.Contracts.Interfaces;
using MovieInfo.Application.Contracts.Services;
using MovieInfo.Infrastructure.Api;
using MovieInfo.Infrastructure.Api.OmdbApi;
using MovieInfo.Infrastructure.Api.OmdbApi.Options;
using MovieInfo.Infrastructure.Api.VimeoApi;
using MovieInfo.Infrastructure.Api.VimeoApi.Options;

namespace MovieInfo.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
           
            services.AddHttpClient(nameof(VimeoApiClient), client =>
            {
                var options = configuration.GetSection(VimeoOptions.SectionName).Get<VimeoOptions>();
                client.BaseAddress = new Uri(options.ApiUri);
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {options.BearerToken}");
            });

            services.AddTransient<IMovieClient, VimeoApiClient>();
            services.AddTransient<IMovieClient, OmdbApiClient>(client =>
            {
                var options = configuration.GetSection(OmdbApiOptions.SectionName).Get<OmdbApiOptions>();
                return new OmdbApiClient(options.ApiKey, options.ApiUri);
            });

            services.AddSingleton<IMovieClientFactory, MovieClientFactory>();


            return services;
        }
    }
}
