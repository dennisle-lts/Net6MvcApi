using Microsoft.AspNetCore.Mvc;
using Net6MvcApi.Contracts.Users;
using Net6MvcApi.Models;
using Net6MvcApi.Services.Users;

namespace Net6MvcApi.Controllers;

[ApiController]
// Endpoint api/User
//[Route(template:"api/[controller]")]
[Route(template: "api/users")]

public class UserController : ControllerBase
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

        _userService.CreateUser(user);

        var response = new UserResponse(user.Id, user.Name, user.Email, user.DateOfBirth, user.CreatedDate, user.ModifiedDate);
        // return Ok(response);
        return CreatedAtAction(
            actionName: nameof(GetUser),
            routeValues: new { id = user.Id },
            value: response
        );
    }

    // GET api/<UserController>/1
    [HttpGet(template: "{id:guid}")]
    public IActionResult GetUser(Guid id)
    {
        User user = _userService.GetUser(id);
        var response = new UserResponse(user.Id, user.Name, user.Email, user.DateOfBirth, user.CreatedDate, user.ModifiedDate);
        return Ok(response);
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

        _userService.UpsertUser(user);
        return NoContent();
        // TODO: return 201 if a new user was created
    }

    [HttpDelete(template: "{id:guid}")]
    public IActionResult DeleteUser(Guid id)
    {
        _userService.DeleteUser(id);
        return NoContent();
    }
}