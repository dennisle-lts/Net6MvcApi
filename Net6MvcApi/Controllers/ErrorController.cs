using Microsoft.AspNetCore.Mvc;

namespace Net6MvcApi.Controllers;

[ApiController]
[Route(template: "error")]
public class ErrorController : ControllerBase
{
    [HttpGet]
    public IActionResult Error()
    {
        return Problem();
    }
}