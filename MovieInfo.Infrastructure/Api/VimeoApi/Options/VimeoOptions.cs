namespace MovieInfo.Infrastructure.Api.VimeoApi.Options
{
    public class VimeoOptions
    {
        public const string SectionName = "Vimeo";

        public string BearerToken { get; set; }
        public string ApiUri { get; set; }
    }
}
