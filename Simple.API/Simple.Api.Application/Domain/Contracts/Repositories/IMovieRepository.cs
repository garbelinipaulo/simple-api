using Simple.Api.Application.Domain.Models;

namespace Simple.Api.Application.Domain.Contracts.Repositories
{
    public interface IMovieRepository
    {
         Task<int> Insert(MovieModel dto);
         Task<bool> Update(MovieModel dto); 
         Task<MovieModel> Get(int id);
         Task<IEnumerable<MovieModel>> GetList(int page, int quantity = 10);
    }
}
