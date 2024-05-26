namespace CustomDapperService.RestApi.Query;

public static class UserQueryList
{
    #region Get All Users Query

    public static string GetAllUsersQuery()
    {
        return @"SELECT [UserId]
      ,[UserName]
      ,[Email]
      ,[Password]
      ,[UserRole]
      ,[Age]
      ,[Gender]
      ,[Address]
      ,[IsActive]
  FROM [dbo].[Users] WHERE IsActive = @IsActive ORDER BY UserId DESC";
    }

    #endregion

    #region Get User Query

    public static string GetUserQuery()
    {
        return @"SELECT [UserId]
      ,[UserName]
      ,[Email]
      ,[Password]
      ,[UserRole]
      ,[Age]
      ,[Gender]
      ,[Address]
      ,[IsActive]
  FROM [dbo].[Users] WHERE UserId = @UserId AND IsActive = @IsActive ORDER BY UserId DESC";
    }

    #endregion
}