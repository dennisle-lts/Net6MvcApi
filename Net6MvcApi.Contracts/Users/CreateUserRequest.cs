namespace Net6MvcApi.Contracts.Users;

public record CreateUserRequest(
    string Name, 
    string Email, 
    DateTime DateOfBirth
);