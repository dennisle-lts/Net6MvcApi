
using ErrorOr;
using Net6MvcApi.Models;
using Net6MvcApi.ServiceErrors;

namespace Net6MvcApi.Services.Users;

public class UserService: IUserService
{
    private static readonly Dictionary<Guid, User> _users = new();
    // Store data to db here
    public ErrorOr<Created> CreateUser(User user)
    {
        _users.Add(user.Id, user);
        return Result.Created;
    }

    public ErrorOr<User> GetUser(Guid id)
    {
        if (_users.TryGetValue(id, out var user))
        {
            return user;
        }
        return Errors.User.NotFound;
    }

    ErrorOr<Deleted> IUserService.DeleteUser(Guid id)
    {
        _users.Remove(id);
        return Result.Deleted;
    }

    ErrorOr<UpsertedUser> IUserService.UpsertUser(User user)
    {
        var isNewlyCreated = !_users.ContainsKey(user.Id);
        _users[user.Id] = user;
        return new UpsertedUser(isNewlyCreated);
    }
}