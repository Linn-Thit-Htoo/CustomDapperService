using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace CustomDapperService.Shared;

public class DapperService
{
    private readonly SqlConnectionStringBuilder _sqlConnectionStringBuilder;

    public DapperService(SqlConnectionStringBuilder sqlConnectionStringBuilder)
    {
        _sqlConnectionStringBuilder = sqlConnectionStringBuilder;
    }

    #region Query
    public List<T> Query<T>(string query, object? parameters = null)
    {
        using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        List<T> lst = db.Query<T>(query, parameters).ToList();
        return lst;
    }

    #endregion

    #region Query Async
    public async Task<IEnumerable<T>> QueryAsync<T>(string query, object? parameters = null)
    {
        using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        IEnumerable<T> lst = await db.QueryAsync<T>(query, parameters);
        return lst;
    }
    #endregion

    #region Query First Or Default
    public T QueryFirstOrDefault<T>(string query, object? parameters = null)
    {
        using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        T item = db.Query<T>(query, parameters).FirstOrDefault()!;
        return item!;
    }
    #endregion

    #region Query First Or Default Async
    public async Task<IEnumerable<T>> QueryFirstOrDefaultAsync<T>(string query, object? parameters = null)
    {
        using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        var item = await db.QueryAsync<T>(query, parameters);
        return item!;
    }
    #endregion

    #region Execute
    public int Execute(string sql, object? parameters = null)
    {
        using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        int result = db.Execute(sql, parameters);
        return result;
    }
    #endregion

    #region Execute Async
    public async Task<int> ExecuteAsync(string sql, object? parameters = null)
    {
        using IDbConnection db = new SqlConnection(_sqlConnectionStringBuilder.ConnectionString);
        int result = await db.ExecuteAsync(sql, parameters);
        return result;
    }
    #endregion
}