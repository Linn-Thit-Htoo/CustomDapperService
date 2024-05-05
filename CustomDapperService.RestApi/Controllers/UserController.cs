using CustomDapperService.RestApi.Models;
using CustomDapperService.Shared;
using Microsoft.AspNetCore.Mvc;

namespace CustomDapperService.RestApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly DapperService _dapperService;

    public UserController(DapperService dapperService)
    {
        _dapperService = dapperService;
    }

    #region Get Users

    [HttpGet]
    public async Task<IActionResult> GetUsers()
    {
        try
        {
            string query = @"SELECT [UserId]
      ,[UserName]
      ,[Email]
      ,[Password]
      ,[UserRole]
      ,[Age]
      ,[Gender]
      ,[Address]
      ,[IsActive]
  FROM [dbo].[Users] WHERE IsActive = @IsActive ORDER BY UserId DESC";
            var parameters = new
            {
                IsActive = true
            };
            IEnumerable<UserModel> lst = await _dapperService.QueryAsync<UserModel>(query, parameters);
            return Ok(lst);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion

    #region Get User

    [HttpPost]
    public async Task<IActionResult> GetUser(int id)
    {
        try
        {
            string query = @"SELECT [UserId]
      ,[UserName]
      ,[Email]
      ,[Password]
      ,[UserRole]
      ,[Age]
      ,[Gender]
      ,[Address]
      ,[IsActive]
  FROM [dbo].[Users] WHERE UserId = @UserId AND IsActive = @IsActive ORDER BY UserId DESC";
            var parameters = new
            {
                UserId = id,
                IsActive = true
            };
            IEnumerable<UserModel> item = await _dapperService.QueryFirstOrDefaultAsync<UserModel>(query, parameters);

            return Ok(item);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion
}