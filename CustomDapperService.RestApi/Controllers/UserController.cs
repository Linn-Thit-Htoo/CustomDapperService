using CustomDapperService.RestApi.Models;
using CustomDapperService.RestApi.Query;
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
            string query = UserQueryList.GetAllUsersQuery();
            IEnumerable<UserModel> lst = await _dapperService.QueryAsync<UserModel>(query, new { IsActive = true });

            return Ok(lst);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion

    #region Get User

    [HttpGet("{id}")]
    public async Task<IActionResult> GetUser(int id)
    {
        try
        {
            string query = UserQueryList.GetUserQuery();
            var parameters = new
            {
                UserId = id,
                IsActive = true
            };
            UserModel? item = await _dapperService.QueryFirstOrDefaultAsync<UserModel>(query, parameters);

            return Ok(item); // if null, default 204
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    #endregion
}