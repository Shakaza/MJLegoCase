using LegoCase.Database.Users;

namespace LegoCase.Core.Users;

public interface IUserService
{
    Task<User> GetCurrentUser();
}
