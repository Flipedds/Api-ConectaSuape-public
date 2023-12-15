using Api.Database;
using Api.models;
using Dapper;

namespace Api.repositories;

public class LoginRepository(IDatabaseConnection db): ILoginRepository
{
    private readonly IDatabaseConnection _db = db;

    public UserDto Authenticate(User user)
    {
       _db.Open();

       var sql = "SELECT * FROM Users WHERE username = @Username AND password = @Password";
        UserDto? query = _db.Connection.QuerySingleOrDefault<UserDto>(sql, new { Username = user.UserName, Password = user.Pass });
        
        return query;
    }
}
