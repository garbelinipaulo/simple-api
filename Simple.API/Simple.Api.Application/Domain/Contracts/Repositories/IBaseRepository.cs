using Dapper;

namespace Simple.Api.Application.Domain.Contracts.Repositories
{
    public interface IBaseRepository
    {
        Task<IEnumerable<T>> DbQueryAsync<T>(string sql, object? parameters = null);
        Task<T> DbQuerySingleAsync<T>(string sql, object parameters);
        Task<bool> DbExecuteAsync(string sql, object parameters);
        Task<bool> DbExecuteScalarAsync(string sql, object parameters);
        Task<T> DbExecuteScalarDynamicAsync<T>(string sql, object? parameters = null);
        Task<(IEnumerable<T> Data, TRecordCount RecordCount)> DbQueryMultipleAsync<T, TRecordCount>(string sql, object? parameters = null);
        DynamicParameters MappingParameters(object obj);
        void StartTransaction();
        void Commit();
        void Rollback();

    }
}
