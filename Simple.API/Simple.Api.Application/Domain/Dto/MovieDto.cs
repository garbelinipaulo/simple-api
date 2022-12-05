namespace Simple.Api.Application.Domain.Dto
{
    public class MovieDto
    {
        public int MovieId { get; set; }
        public string? MovieTitle { get; set; }
        public string? Observation
        {
            get
            {
                return MovieAvailable ? $"The movie {MovieTitle} is available" : $"The movie {MovieTitle} is  not available";
            }
        }
        public bool MovieAvailable { get; set; }
    }
}
