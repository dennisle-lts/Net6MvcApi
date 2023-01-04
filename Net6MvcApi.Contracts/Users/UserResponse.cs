namespace Net6MvcApi.Contracts.Users;

public record UserResponse(
    Guid Id,
    string Name,
    string Email,
    DateTime DateOfBirth,
    DateTime CreatedDate,
    DateTime ModifiedDate
);