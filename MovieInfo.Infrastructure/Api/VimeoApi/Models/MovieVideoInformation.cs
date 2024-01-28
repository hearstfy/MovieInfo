namespace MovieInfo.Infrastructure.Api.VimeoApi.Models
{
    public class Datum
    {
        public string uri { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public string link { get; set; }
    }


    public class Paging
    {
        public string next { get; set; }
        public object previous { get; set; }
        public string first { get; set; }
        public string last { get; set; }
    }

    public class MovieVideoInformation
    {
        public int total { get; set; }
        public int page { get; set; }
        public int per_page { get; set; }
        public Paging paging { get; set; }
        public List<Datum> data { get; set; }
    }
}
