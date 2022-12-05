using Simple.Api.Application.Domain.Contracts.Repositories;
using Simple.Api.Application.Domain.Models;
using Simple.Api.Application.Infra.Repositories.Queries;

namespace Simple.Api.Application.Infra.Repositories
{
    internal class MovieRepository : IMovieRepository
    {
        private readonly IBaseRepository _baseRepository;
        public MovieRepository(IBaseRepository baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public async Task<int> Insert(MovieModel dto) =>
        await _baseRepository.DbQuerySingleAsync<int>(MovieQuery.InsertMovie, _baseRepository.MapearParametros(dto));

        public async Task<bool> Update(MovieModel dto) =>
        await _baseRepository.DbExecuteAsync(MovieQuery.UpdateMovie, _baseRepository.MapearParametros(dto));
          
        public async Task<MovieModel> Get(int id) =>
        await _baseRepository.DbQuerySingleAsync<MovieModel>(MovieQuery.GetMovie, new { id = id });

        public async Task<IEnumerable<MovieModel>> GetList(int page, int quantity = 10) =>
         await _baseRepository.DbQueryAsync<MovieModel>(MovieQuery.GetListMovies, new
         {
             page = page,
             quantity = quantity
         });
    }
}
