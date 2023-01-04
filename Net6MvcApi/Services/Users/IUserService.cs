using Net6MvcApi.Models;

namespace Net6MvcApi.Services.Users;

public interface IUserService
{
    void CreateUser(User user);
    void DeleteUser(Guid id);
    User GetUser(Guid id);
    void UpsertUser(User user);
}