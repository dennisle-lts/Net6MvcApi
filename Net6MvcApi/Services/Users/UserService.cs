using Net6MvcApi.Models;

namespace Net6MvcApi.Services.Users;

public class UserService: IUserService
{
    private static readonly Dictionary<Guid, User> _users = new();
    // Store data to db here
    public void CreateUser(User user)
    {
        _users.Add(user.Id, user);
    }

    public User GetUser(Guid id)
    {
        return _users[id];
    }

    void IUserService.DeleteUser(Guid id)
    {
        _users.Remove(id);
    }

    void IUserService.UpsertUser(User user)
    {
        _users[user.Id] = user;
    }
}