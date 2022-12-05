using Dapper;
using Simple.Api.Application.Domain.Contracts.Repositories;
using System.Data;
using System.Data.SqlClient; 

namespace Simple.Api.Application.Infra.Repositories.Base
{
    public class BaseRepository : IBaseRepository
    {
        private SqlConnection Connection { get; set; }
        private readonly string _DbConnectionString;
        private IDbTransaction transaction;

        public BaseRepository(string DbConnectionString)
        {
            _DbConnectionString = DbConnectionString;
        }

        #region Single operation with single connection

        public async Task<IEnumerable<T>> DbQueryAsync<T>(string sql, object? parameters = null)
        {
            InstanceConnection();
            using var dbCon = Connection;
            return parameters == null ? await dbCon.QueryAsync<T>(sql) : await dbCon.QueryAsync<T>(sql, parameters);
        }
        public async Task<T> DbQuerySingleAsync<T>(string sql, object parameters)
        {
            InstanceConnection();
            return await Connection.QueryFirstOrDefaultAsync<T>(sql, parameters);
        }

        public async Task<bool> DbExecuteAsync(string sql, object parameters)
        {
            InstanceConnection();
            return await Connection.ExecuteAsync(sql, parameters) > 0;
        }

        public async Task<bool> DbExecuteScalarAsync(string sql, object parameters)
        {
            InstanceConnection();
            return await Connection.ExecuteScalarAsync<bool>(sql, parameters);
        }

        public async Task<T> DbExecuteScalarDynamicAsync<T>(string sql, object? parameters = null)
        {
            InstanceConnection();
            return parameters == null ? await Connection.ExecuteScalarAsync<T>(sql) : await Connection.ExecuteScalarAsync<T>(sql, parameters);
        }

        public async Task<(IEnumerable<T> Data, TRecordCount RecordCount)> DbQueryMultipleAsync<T, TRecordCount>(string sql, object? parameters = null)
        {
            InstanceConnection();
            IEnumerable<T>? data = null;
            TRecordCount totalRecords;

            using (var dbCon = Connection)
            {
                using var results = await dbCon.QueryMultipleAsync(sql, parameters);
                data = await results.ReadAsync<T>();
                totalRecords = await results.ReadSingleAsync<TRecordCount>();
            }

            return (data, totalRecords);
        }
        #endregion
         

        public DynamicParameters MapearParametros(object obj)
        {
            return new DynamicParameters(obj);
        }

        public void IniciarTransacao()
        {
            InstanceConnection();
            Connection.Open();
            transaction = Connection.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
            Connection.Close();
            Connection.Dispose();
        }

        public void Rollback()
        {
            transaction.Rollback();
            Connection.Close();
            Connection.Dispose();
        }

        private void InstanceConnection()
        {
            Connection = new SqlConnection(_DbConnectionString);
        }
    }
}
