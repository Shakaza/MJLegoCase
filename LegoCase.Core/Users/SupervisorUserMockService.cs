using LegoCase.Database.Users;

namespace LegoCase.Core.Users;

public class SupervisorUserMockService : IUserService
{
    public Task<User> GetCurrentUser()
    {
        return Task.FromResult(new User
        {
            UserId = Guid.NewGuid(),
            Role = UserRole.Supervisor,
            Name = "Supervisor"
        });
    }
}
