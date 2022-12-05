using Simple.Api.Application.Domain.Dto;

namespace Simple.Api.Application.Domain.Contracts
{
    public interface IMovieService
    {
        Task<MovieDto> GetMovie(int? idMovie);
        Task<List<MovieDto>> GetListMovie(int page, int? quantity);
        Task<int?> InsertMovie(MovieDto obj);
        Task<bool> UpdateMovie(MovieDto obj);
    }
}
