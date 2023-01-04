namespace Net6MvcApi.Contracts.Users;

public record UpsertUserRequest(
    string Name, 
    string Email, 
    DateTime DateOfBirth
);