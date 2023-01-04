using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using Net6MvcApi.Contracts.Users;
using Net6MvcApi.Models;
using Net6MvcApi.ServiceErrors;
using Net6MvcApi.Services.Users;

namespace Net6MvcApi.Controllers;

[Route(template: "api/users")]
public class UserController : ApiController
{

    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    // POST api/<UserController>
    [HttpPost]
    public IActionResult CreateUser(CreateUserRequest request)
    {
        var user = new User(Guid.NewGuid(), request.Name, request.Email, request.DateOfBirth, DateTime.UtcNow, DateTime.UtcNow);

        ErrorOr<Created> createUserResult = _userService.CreateUser(user);

        return createUserResult.Match(
            created => CreatedAtGetUser(user),
            errors => Problem(errors)
        );
    }



    // GET api/<UserController>/1
    [HttpGet(template: "{id:guid}")]
    public IActionResult GetUser(Guid id)
    {
        ErrorOr<User> getUserResult = _userService.GetUser(id);
        return getUserResult.Match(
            user => Ok(MapUserResponse(user)),
            errors => Problem(errors)
        );
    }



    // PUT api/<UserController>/1
    [HttpPut(template: "{id:guid}")]
    public IActionResult UpsertUser(Guid id, UpsertUserRequest request)
    {
        var user = new User(
            id,
            request.Name,
            request.Email,
            request.DateOfBirth,
            DateTime.UtcNow,
            DateTime.UtcNow
        );

        ErrorOr<UpsertedUser> upsertedUserResult =  _userService.UpsertUser(user);
        
        return upsertedUserResult.Match(
            upserted => upserted.IsNewlyCreated ? CreatedAtGetUser(user):NoContent(),
            errors => Problem(errors)
        );
    }

    [HttpDelete(template: "{id:guid}")]
    public IActionResult DeleteUser(Guid id)
    {
        ErrorOr<Deleted> deletedUserResult = _userService.DeleteUser(id);
        return deletedUserResult.Match(
            deleted => NoContent(),
            errors => Problem(errors)
        );
    }

    private static UserResponse MapUserResponse(User user)
    {
        return new UserResponse(
            user.Id,
            user.Name,
            user.Email,
            user.DateOfBirth,
            user.CreatedDate,
            user.ModifiedDate
        );
    }

        private IActionResult CreatedAtGetUser(User user)
    {
        return CreatedAtAction(
                    actionName: nameof(GetUser),
                    routeValues: new { id = user.Id },
                    value: MapUserResponse(user)
                );
    }
}