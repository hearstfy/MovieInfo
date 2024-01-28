namespace MovieInfo.Infrastructure.Api.OmdbApi.Options
{
    public class OmdbApiOptions
    {
        public static string SectionName = "OmdbApi";
        public string ApiKey { get; set; }
        public string ApiUri { get; set; }
    }
}
