using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CustomDapperService.DapperService
{
    public class DapperService
    {
        private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

        public DapperService(SqlConnectionStringBuilder sqlConnectionStringBuilder)
        {
            _sqlConnectionStringBuilder = sqlConnectionStringBuilder;
        }

        public List<T> Query<T>(string query, object? parameters = null)
        {
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            List<T> lst = db.Query<T>(query, parameters).ToList();
            return lst;
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string query, object? parameters = null)
        {
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            IEnumerable<T> lst = await db.QueryAsync<T>(query, parameters);
            return lst;
        }

        public int Execute(string sql, object? parameters = null)
        {
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = db.Execute(sql, parameters);
            return result;
        }

        public async Task<int> ExecuteAsync(string sql, object? parameters = null)
        {
            using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
            int result = await db.ExecuteAsync(sql, parameters);
            return result;
        }
    }
}