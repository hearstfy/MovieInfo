using MovieInfo.Application.Contracts.Interfaces;
using MovieInfo.Application.Contracts.Services;
using System.Xml.Linq;

namespace MovieInfo.Infrastructure.Api
{
    public class MovieClientFactory: IMovieClientFactory
    {
        private readonly IEnumerable<IMovieClient> _clients;

        public MovieClientFactory(IEnumerable<IMovieClient> clients)
        {
            _clients = clients.ToList();
        }

        public IMovieClient GetMovieClient(string movieClientType)
        {
            return _clients.FirstOrDefault(c => c.GetName() == movieClientType);
        }
    }
}
