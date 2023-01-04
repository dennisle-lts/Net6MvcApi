using ErrorOr;
using Net6MvcApi.Models;

namespace Net6MvcApi.Services.Users;

public interface IUserService
{
    ErrorOr<Created> CreateUser(User user);
    ErrorOr<Deleted> DeleteUser(Guid id);
    ErrorOr<User> GetUser(Guid id);
    ErrorOr<UpsertedUser> UpsertUser(User user);
}