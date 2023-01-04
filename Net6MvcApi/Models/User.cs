namespace Net6MvcApi.Models;

public class User
{
    public Guid Id { get; }
    public string Name { get; }
    public string Email { get; }
    public DateTime DateOfBirth { get; }
    public DateTime CreatedDate { get; }
    public DateTime ModifiedDate { get; }

    public User(Guid id, string name, string email, DateTime dateOfBirth, DateTime createdDate, DateTime modifiedDate)
    {
        Id = id;
        Name = name;
        Email = email;
        DateOfBirth = dateOfBirth;
        CreatedDate = createdDate;
        ModifiedDate = modifiedDate;
    }
}